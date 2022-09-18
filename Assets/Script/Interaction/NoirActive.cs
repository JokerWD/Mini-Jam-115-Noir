using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Zenject;

namespace Noir
{
    public class NoirActive : MonoBehaviour
    {
        [SerializeField] private PostProcessVolume _postProcess;
        [SerializeField] private StateManager _state;
        [SerializeField] private GameObject _normal;
        
        private Bloom _bloom;
        private AmbientOcclusion _ambientOcclusion;
        private AutoExposure _autoExposure;
        private KeyboardPlayer _keyboardPlayer;
        
        [Inject]
        private void Construct(Player player, KeyboardPlayer keyboardPlayer) => _keyboardPlayer = keyboardPlayer;

        private void Awake()
        {
            GetSettings();
        }

        private void OnEnable() => _keyboardPlayer.OnNoir += OnNoir;
        private void OnDisable() => _keyboardPlayer.OnNoir -= OnNoir;

        private void OnNoir(bool IsNoir)
        {
            if (IsNoir)
            {
                _normal.gameObject.SetActive(false);
                _state.State[0].gameObject.SetActive(true);
            }
            else
            {
                _state.State[0].gameObject.SetActive(false);
                _normal.gameObject.SetActive(true);
            }

            SetActivePost();
        }

        private void GetSettings()
        {
            _postProcess.profile.TryGetSettings(out _bloom);
            _postProcess.profile.TryGetSettings(out _ambientOcclusion);
            _postProcess.profile.TryGetSettings(out _autoExposure);
        }
        private void SetActivePost()
        {
            _bloom.active = !_bloom.active;
            _ambientOcclusion.active = !_ambientOcclusion.active;
            _autoExposure.active = !_autoExposure.active;
        }
    }
}
