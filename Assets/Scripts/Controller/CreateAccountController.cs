using Entity;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Controller
{
    public class CreateAccountController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Text text;
        public InputField email;
        public InputField password;
        public InputField confirmPassword;

        public GameObject mainMenuCanvas;
        public GameObject createAccountCanvas;
        
        public GameObject errorMessage;
        public GameObject errorMessageEmail;
        public GameObject errorMessagePassword;
        public GameObject errorMessagePasswordCheck;

        private bool _errors;

        private DDOL _ddol;
        private Color _initColor;
        private void Start()
        {
            _initColor = text.color;
            errorMessage.SetActive(false);
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            _errors = false;
        }
        
        private void Update()
        {
            if (_ddol.networkManager.requestTreated)
            {
                if (_ddol.player != null)
                {
                    createAccountCanvas.SetActive(false);
                    mainMenuCanvas.SetActive(true);             
                }
                else
                {
                    errorMessage.SetActive(true);
                    errorMessage.GetComponent<Text>().text = _ddol.GetComponent<DDOL>().responseRequest.detail;
                }
                
                _ddol.networkManager.requestTreated = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_ddol.networkManager.isNetworkAvailable)
            {
                ResetValues();
                ControlFields();
                
                if (_errors)
                    return;

                CreateUser();
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

        private void ResetValues()
        {
            _errors = false;
            
            errorMessageEmail.SetActive(false);
            errorMessagePassword.SetActive(false);
            errorMessagePasswordCheck.SetActive(false);
        }
        private void ControlFields()
        {
            var emailCheck = email.text.Replace(" ", null);
            var passwordCheck = password.text.Replace(" ", null);
            var passwordSecondValidCheck = confirmPassword.text.Replace(" ", null);

            if (emailCheck.Length < 6)
            {
                errorMessageEmail.GetComponent<Text>().text = "Error with email";
                errorMessageEmail.SetActive(true);
                _errors = true;
            }

            if (passwordCheck.Length < 6)
            {
                errorMessagePassword.GetComponent<Text>().text = "error with password";
                errorMessagePassword.SetActive(true);
                _errors = true;
            }
                
            if (passwordCheck != passwordSecondValidCheck)
            {
                errorMessagePasswordCheck.GetComponent<Text>().text = "this confirm password isn't same as password";
                errorMessagePasswordCheck.SetActive(true);
                _errors = true;
            }
        }
        
        private void CreateUser()
        {
            PlayerCreateAccountEntity createAccountData = new PlayerCreateAccountEntity(email.text, password.text);
            var form = new WWWForm();
            form.AddField("email", createAccountData.email);
            form.AddField("password", createAccountData.password);
            form.AddField("name", createAccountData.name);
            
            _ddol.networkManager.CreateAccount(form);
        }
    }
}
