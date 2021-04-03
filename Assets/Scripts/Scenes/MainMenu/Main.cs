using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Scenes.MainMenu
{
    public class Main : MonoBehaviour , IPointerClickHandler
    {
        public bool isStart;
        public bool isQuit;

        public void OnPointerClick(PointerEventData eventData)
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
