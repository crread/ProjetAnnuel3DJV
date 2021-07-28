using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.MainMenu
{
    public class SelectLanguageButton : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {

        public bool englishButton;
        public Text text;
        
        private Color _initColor;
        private DDOL _ddol;
        void Start()
        {
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            _initColor = text.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = Color.red;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetColor();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (englishButton)
            {
                if (!_ddol.translates.isEnglishVersionsLoaded)
                {
                    _ddol.translates.GenerateEnglishTranslate();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    _ddol.translates.isEnglishVersionsLoaded = true;
                }
            }
            else
            {
                if (_ddol.translates.isEnglishVersionsLoaded)
                {
                    _ddol.translates.GenerateFrenchTranslate();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    _ddol.translates.isEnglishVersionsLoaded = false;
                }
            }
        }
        
        private void ResetColor()
        {
            text.color = _initColor;
        }
    }
}
