using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public class SceneController : MonoBehaviour
    {
        public void Quit()
        {
            Application.Quit();
        }

        public void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}