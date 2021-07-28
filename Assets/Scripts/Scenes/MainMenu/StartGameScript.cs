using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.MainMenu
{
    public class StartGameScript : MonoBehaviour , IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
    {
        public Text text;
        private Color _initColor;
        
        private DDOL _ddol;
        private void Start()
        {
            _initColor = text.color;
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = Color.red;
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            text.color = _initColor;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_ddol.gameData.selectedLevelName != "")
            {
                SceneManager.LoadScene(_ddol.gameData.selectedLevelName);
                _ddol.gameData.selectedLevelName = "";
            }
        }
    }
}
