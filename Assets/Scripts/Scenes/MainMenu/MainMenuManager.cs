﻿using System.Collections.Generic;
using UnityEngine;

namespace Scenes.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public GameObject mainMenuCanvas;
        public GameObject loginCanvas;
        public List<GameObject> lisNetworkMessageErrors = new List<GameObject>();

        public GameObject loginGameObject;
        public GameObject logoutGameObject;
        public GameObject createAccountGameObject;
        
        private bool _currentNetworkState;
        private DDOL _ddol;
        void Start()
        {
            GameObject preload = GameObject.Find("Preload");
            _ddol = preload.GetComponent<DDOL>();
            
            _currentNetworkState = _ddol.networkManager.isNetworkAvailable;
            ChangeNetworkMessageStatus();
            
            if (!_currentNetworkState || _ddol.isLoaded)
            {
                loginCanvas.SetActive(false);
                mainMenuCanvas.SetActive(true);
            }
            
            if (_currentNetworkState)
            {
                _ddol.isLoaded = true;
            }
        }
        
        void Update()
        {
            if (_currentNetworkState != _ddol.networkManager.isNetworkAvailable)
            {
                _currentNetworkState = _ddol.networkManager.isNetworkAvailable;
                ChangeNetworkMessageStatus();
            }
            
            if (_ddol.player.name != null)
            {
                logoutGameObject.SetActive(true);
                loginGameObject.SetActive(false);
                createAccountGameObject.SetActive(false);
            }
            else
            {
                logoutGameObject.SetActive(false);
                loginGameObject.SetActive(true);
                createAccountGameObject.SetActive(true);
            }
        }

        private void ChangeNetworkMessageStatus()
        {
            foreach (var message in lisNetworkMessageErrors)
            {
                message.SetActive(!_currentNetworkState);
            }
        }
    }
}
