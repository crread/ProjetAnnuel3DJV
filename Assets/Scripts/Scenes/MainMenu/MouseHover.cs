using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Scenes.MainMenu
{
    public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Text text;
        public enum ListOfInteraction {Campaign, CustomGame, Editor, Login, Create, Options, Quit, Return};
        public ListOfInteraction buttonType;
        public GameObject canvasToOpen;

        private Color _initColor;

        private void Start()
        {
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

        /**
         * !TODO Switch condition must be factorize
         */
        public void OnPointerClick(PointerEventData eventData)
        {
            ResetColor();
            switch (buttonType)
            {
                case ListOfInteraction.Campaign:
                case ListOfInteraction.CustomGame:
                case ListOfInteraction.Editor:
                case ListOfInteraction.Login:
                case ListOfInteraction.Create:
                case ListOfInteraction.Options:
                case ListOfInteraction.Return:
                    canvasToOpen.SetActive(true);
                    GetComponentInParent<Canvas>().gameObject.SetActive(false);
                    break;
                case ListOfInteraction.Quit :
                    Application.Quit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ResetColor()
        {
            text.color = _initColor;
        }
    }
}
