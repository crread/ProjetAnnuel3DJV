using Entity;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Controller
{
    public class LoginController : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Text text;
        public InputField email;
        public InputField password;
        public GameObject mainMenuCanvas;
        public GameObject loginCanvas;
        public GameObject errorMessage;

        private GameObject _preload;
        private Color _initColor;
        
        private void Start()
        {
            _initColor = text.color;
            errorMessage.SetActive(false);
            _preload = GameObject.Find("Preload");
        }

        private void Update()
        {
            if (_preload.GetComponent<DDOL>().networkManager.requestTreated)
            {
                if (_preload.GetComponent<DDOL>().player.token != null)
                {
                    loginCanvas.SetActive(false);
                    mainMenuCanvas.SetActive(true);             
                }
                else
                {
                    errorMessage.SetActive(true);
                    errorMessage.GetComponent<Text>().text = _preload.GetComponent<DDOL>().responseRequest.detail;
                }

                _preload.GetComponent<DDOL>().networkManager.requestTreated = false;
            }
        }

        /// <summary>
        ///   <para>Catch data from email and password field and start a request to the API.</para>
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_preload.GetComponent<DDOL>().networkManager.isNetworkAvailable)
            {
                LoginEntity loginData = new LoginEntity(email.text, password.text);
                _preload.GetComponent<DDOL>().networkManager.GetUser(JsonConvert.SerializeObject(loginData));
            }
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
