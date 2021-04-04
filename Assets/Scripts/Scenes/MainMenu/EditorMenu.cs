using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Scenes.MainMenu
{
    public class EditorMenu : MonoBehaviour , IPointerClickHandler
    {
        private Scene _testScene;

        public void OnPointerClick(PointerEventData eventData)
        {
            
            _testScene = SceneManager.CreateScene("test");
            SceneManager.LoadScene("test");
        }
    }
}