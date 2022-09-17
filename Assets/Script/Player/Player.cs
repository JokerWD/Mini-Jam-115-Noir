using System;
using UnityEngine;

namespace Noir
{
    public class Player : MonoBehaviour
    {
        public bool IsNoir { get;  set; } = false;
        [field: SerializeField] public int CountNoir { get;  set; }
        [field: SerializeField] public int RoomNumber {get; set; } = 0;

        private void Awake() => CountNoir *= 2;
    }
}

