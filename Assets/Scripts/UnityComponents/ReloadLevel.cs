using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pirates.Components
{
    public class ReloadLevel : MonoBehaviour
    {
        public void Do()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}