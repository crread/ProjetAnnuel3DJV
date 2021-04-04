using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes.MainMenu
{
    public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Text text;

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
            text.color = _initColor;
        }
    }
}
