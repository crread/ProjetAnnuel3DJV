﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.MainMenu
{
    public class SceneLoader : MonoBehaviour , IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
    {
        public Text text;
        public string sceneName;
        
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
        
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
