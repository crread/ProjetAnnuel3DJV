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
            Debug.Log(SceneManager.sceneCount);
            _testScene = SceneManager.CreateScene("test");
            Debug.Log(SceneManager.sceneCount);
            Debug.Log(_testScene.path);
            Debug.Log(_testScene.name);
            Debug.Log(_testScene.buildIndex);
        }
    }
}