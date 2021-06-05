using System.Collections.Generic;
using UnityEngine;

namespace Scenes.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public GameObject mainMenuCanvas;
        public GameObject loginCanvas;
        public List<GameObject> lisNetworkMessageErrors = new List<GameObject>();
        
        private bool _currentNetworkState;
        private DDOL _ddol;
        void Start()
        {
            GameObject preload = GameObject.Find("Preload");
            _ddol = preload.GetComponent<DDOL>();
            
            _currentNetworkState = _ddol.networkManager.isNetworkAvailable;
            ChangeNetworkMessageStatus();
            
            if (_currentNetworkState)
            {
                loginCanvas.SetActive(true);
                _ddol.isLoaded = true;
            }
            else
            { 
                mainMenuCanvas.SetActive(true);
            }
        }
        
        void Update()
        {
            if (_currentNetworkState != _ddol.networkManager.isNetworkAvailable)
            {
                _currentNetworkState = _ddol.networkManager.isNetworkAvailable;
                ChangeNetworkMessageStatus();
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
