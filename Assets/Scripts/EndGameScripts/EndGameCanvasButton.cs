using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EndGameScripts
{
    public class EndGameCanvasButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {

        private Text _button;
        public enum ListOfInteraction {Quit, NextMap, Retry};
        public ListOfInteraction buttonType;
        private Color _initColor;
        private DDOL _ddol;
        private void OnEnable()
        {
            _button = GetComponent<Text>();
            _initColor = _button.color;
            _ddol = _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _button.color = Color.red;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetColor();
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            ResetColor();
            switch (buttonType)
            {
                case ListOfInteraction.NextMap :
                    Debug.Log("keep waiting for the map editor");
                    break;
                case ListOfInteraction.Retry :
                    // !TODO Must make the json parser for data.
                    // _ddol.networkManager.UploadEndGameLevelData();
                    SceneManager.LoadScene($"{_ddol.GetLastSceneNamePlayed()}");
                    break;
                case ListOfInteraction.Quit :
                    Debug.Log("save async must be implemented later");
                    SceneManager.LoadScene("mainMenu");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    
        private void ResetColor()
        {
            _button.color = _initColor;
        }
    }
}
