using System;
using UnityEngine;
using Zenject;

namespace Noir
{
    public class KeyboardPlayer : MonoBehaviour
    {
        private Player _player;
        private Teleport _teleport;
        public event Action<bool> OnNoir; 


        [Inject]
        private void Construct(Player player, Teleport teleport)
        {
            _player = player;
            _teleport = teleport;

        }

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

