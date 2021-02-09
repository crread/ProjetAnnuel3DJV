using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
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
            else
            {
                Application.Quit();
            }
        }
    }
}
