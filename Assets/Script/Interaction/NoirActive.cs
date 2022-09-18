using UnityEngine;
using Zenject;

namespace Noir
{
    public class NoirActive : MonoBehaviour
    {
        [SerializeField] private SateManager _state;
        [SerializeField] private GameObject _normal;
        
        private KeyboardPlayer _keyboardPlayer;
        
        [Inject]
        private void Construct(Player player, KeyboardPlayer keyboardPlayer) => _keyboardPlayer = keyboardPlayer;

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
        }
    }
}
