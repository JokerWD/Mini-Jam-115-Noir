using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Noir
{
    public class StateManager : MonoBehaviour
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
                    State[i] = null;
                }
            }

            for (int i = 0; i < State.Count; i++)
            {
                if (State[i] == null)
                {
                    State.Remove(State[i]);
                    i--;
                }
            }
        }
  
    }
}
