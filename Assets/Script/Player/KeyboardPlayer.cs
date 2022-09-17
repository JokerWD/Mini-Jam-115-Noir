using System;
using UnityEngine;
using Zenject;

namespace Noir
{
    public class KeyboardPlayer : MonoBehaviour
    {
        private Player _player;
        public event Action<bool> OnNoir; 


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
        }
    }
}

