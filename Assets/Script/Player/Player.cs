using UnityEngine;

namespace Noir
{
    public class Player : MonoBehaviour
    {
        public bool IsNoir { get;  set; }
        [field: SerializeField] public int CountNoir { get;  set; }

        private void Awake() => CountNoir *= 2;
    }
}

