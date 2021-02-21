using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.MainMenu
{
    public class Main : MonoBehaviour
    {
        public bool isStart;
        public bool isQuit;

        private void OnMouseUp()
        {
            if (isStart)
            {
                SceneManager.LoadScene("firstMap");
            }
            if (isQuit)
            {
                Application.Quit();
            }
        }
    }
}
