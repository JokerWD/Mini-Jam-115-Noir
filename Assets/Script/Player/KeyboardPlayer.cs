using System;
using UnityEngine;
using Zenject;

namespace Noir
{
    public class KeyboardPlayer : MonoBehaviour
    {
        public event Action<bool> OnNoir;

        [SerializeField] private GameObject _playerBook;
        
        private Player _player;


        [Inject]
        private void Construct(Player player) => _player = player;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.N) && _player.CountNoir > 0)
            {
                _player.IsNoir = !_player.IsNoir;
                OnNoir?.Invoke(_player.IsNoir);
                _player.CountNoir--;
            }

            if (Input.GetKeyUp(KeyCode.J) && !_player.IsNoir)
            {
                _playerBook.SetActive(!_playerBook.activeSelf);
                if (_playerBook.activeSelf)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                
            }
            
        }
    }
}

