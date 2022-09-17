using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Noir
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private List<Transform> _positionRoom;

        private Vector3 _lastPositionPlayer;
        private Player _player;
        private KeyboardPlayer _keyboardPlayer;
        
        [Inject]
        private void Construct(Player player, KeyboardPlayer keyboardPlayer)
        {
            _player = player;
            _keyboardPlayer = keyboardPlayer;
        }

        private void OnEnable() => _keyboardPlayer.OnNoir += OnTeleportInRoom;

        private void OnDisable() => _keyboardPlayer.OnNoir -= OnTeleportInRoom;


        private void OnTeleportInRoom(bool IsNoir)
        {
            var player = _player.gameObject;
            if (IsNoir)
            {
                _lastPositionPlayer = player.transform.position;
                player.transform.position = _positionRoom[_player.RoomNumber].transform.position;
            }
            else 
                _player.gameObject.transform.position = _lastPositionPlayer;
        }
        
        
    }
}
