using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Noir
{
    public class NextLevel : MonoBehaviour
    {
        public void Restart(int index)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - index);
        }

      
    }
}
