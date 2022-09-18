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
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _noir;
        [SerializeField] private AudioClip _normalMos;
        
        private Bloom _bloom;
        private AmbientOcclusion _ambientOcclusion;
        private AutoExposure _autoExposure;
        private ColorGrading _colorGrading;
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
                _audioSource.clip = _noir;
                _audioSource.Play();
            }
            else
            {
                _state.State[0].gameObject.SetActive(false);
                _normal.gameObject.SetActive(true);
                _audioSource.clip = _normalMos;
                _audioSource.Play();
            }

            SetActivePost();
            
        }

        private void GetSettings()
        {
            _postProcess.profile.TryGetSettings(out _bloom);
            _postProcess.profile.TryGetSettings(out _ambientOcclusion);
            _postProcess.profile.TryGetSettings(out _autoExposure);
            _postProcess.profile.TryGetSettings(out _colorGrading);
        }
        private void SetActivePost()
        {
            _bloom.active = !_bloom.active;
            _ambientOcclusion.active = !_ambientOcclusion.active;
            _autoExposure.active = !_autoExposure.active;
            _colorGrading.active = !_colorGrading.active;
        }
    }
}
