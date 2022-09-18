using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Noir
{
    public class SateManager : MonoBehaviour
    {
        [field:SerializeField] public List<GameObject> State { get; private set; }

        private void Awake()
        {
            var randomNumberState = Random.Range(0, State.Count);
            for (int i = 0; i < State.Count; i++)
            {
                if (i != randomNumberState)
                {
                    Destroy(State[i]);
                    State.Remove(State[i].gameObject);
                }
            }
        }
    }
}
