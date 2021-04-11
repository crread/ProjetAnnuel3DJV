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
        
        private Color _initColor;
        
        public void Start()
        {
            _initColor = text.color;
            errorMessage.SetActive(false);
        }

        /// <summary>
        ///   <para>Catch data from email and password field and start a request to the API.</para>
        /// </summary>
        
        public void OnPointerClick(PointerEventData eventData)
        {
            GameObject preload = GameObject.Find("Preload");
            
            if (preload.GetComponent<DDOL>().networkManager.isNetworkAvailable)
            {
                LoginEntity loginData = new LoginEntity(email.text, password.text);

                preload.GetComponent<DDOL>().networkManager.GetUser(JsonConvert.SerializeObject(loginData));
            
                if (preload.GetComponent<DDOL>().player != null)
                {
                    loginCanvas.SetActive(false);
                    mainMenuCanvas.SetActive(true);
                }
                else
                {
                    if (preload.GetComponent<DDOL>().responseRequest.httpCode == 401)
                    {
                        errorMessage.SetActive(true);
                    }
                }
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
