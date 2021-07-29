using System;
using UnityEngine;
using UnityEngine.UI;

namespace Translates
{
    public class MainMenuTranslate : MonoBehaviour
    {
        private DDOL _ddol;
        // main menu canvas
        
        public GameObject mainMenuCampaignButton;
        public GameObject mainMenuCustomButton;
        public GameObject mainMenuEditorButton;
        public GameObject mainMenuCreateAccount;
        public GameObject mainMenuConnectButton;
        public GameObject mainMenuDisconnectButton;
        public GameObject mainMenuOptionButton;
        public GameObject mainMenuQuit;

        // menu options
    
        public GameObject optionMenuFrenchButton;
        public GameObject optionMenuEnglishButton;
        public GameObject optionMenuQuit;
    
        // menu select campaign
    
        public GameObject campaignMenuCampaign1;
        public GameObject campaignMenuCampaign2;
        public GameObject campaignMenuCampaign3;
        public GameObject campaignMenuScoreBoardTitle;
        public GameObject campaignMenuQuit;
        public GameObject campaignMenuPlay;
        public GameObject campaignMenuPersonalBest;

        // custom menu
    
        public GameObject customMenuQuit;
    
        //login menu
    
        public GameObject loginMenuTitle;
        public GameObject loginMenuPlaceholderEmail;
        public GameObject loginMenuPlaceholderPassword;
        public GameObject loginMenuLogin;
        public GameObject loginMenuQuit;
    
        // editor canvas
    
        public GameObject editorMenuQuit;
        public GameObject editorMenuRunEditor;
    
        // create account menu
    
        public GameObject createAccountMenuTitle;
        public GameObject createAccountMenuPlaceholderEmail;
        public GameObject createAccountMenuPlaceholderPassword;
        public GameObject createAccountMenuPlaceholderValidPassword;
        public GameObject createAccountMenuCreate;
        public GameObject createAccountMenuQuit;
    
        // list networks error message
    
        public GameObject[] listNetworks;

        private void Awake()
        {
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
        }

        void Start()
        { 
            mainMenuCampaignButton.GetComponent<Text>().text = _ddol.translates.translation["mainPage.campaign"];
            mainMenuCustomButton.GetComponent<Text>().text = _ddol.translates.translation["mainPage.custom"];
            mainMenuEditorButton.GetComponent<Text>().text = _ddol.translates.translation["mainPage.editor"];
            mainMenuCreateAccount.GetComponent<Text>().text = _ddol.translates.translation["mainPage.newAccount"];
            mainMenuConnectButton.GetComponent<Text>().text = _ddol.translates.translation["mainPage.login"];
            mainMenuDisconnectButton.GetComponent<Text>().text = _ddol.translates.translation["mainPage.logout"];
            mainMenuOptionButton.GetComponent<Text>().text = _ddol.translates.translation["mainPage.options"];
            mainMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["mainPage.quitGame"];
            
            optionMenuFrenchButton.GetComponent<Text>().text = _ddol.translates.translation["options.language.french"];
            optionMenuEnglishButton.GetComponent<Text>().text = _ddol.translates.translation["options.language.english"];
            optionMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["options.quit"];
            
            campaignMenuCampaign1.GetComponent<Text>().text = $"{_ddol.translates.translation["campaign.campaign"]} 1";
            campaignMenuCampaign2.GetComponent<Text>().text = $"{_ddol.translates.translation["campaign.campaign"]} 2";
            campaignMenuCampaign3.GetComponent<Text>().text = $"{_ddol.translates.translation["campaign.campaign"]} 3";
            campaignMenuScoreBoardTitle.GetComponent<Text>().text = _ddol.translates.translation["campaign.boardScoreTitle"];
            campaignMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["campaign.quitCampaignMenu"];
            campaignMenuPlay.GetComponent<Text>().text = _ddol.translates.translation["campaign.playGame"];
            campaignMenuPersonalBest.GetComponent<Text>().text = _ddol.translates.translation["campaign.boardPersonalScore"];

            customMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["custom.quit"];
            
            loginMenuTitle.GetComponent<Text>().text = _ddol.translates.translation["login.title"];
            loginMenuPlaceholderEmail.GetComponent<Text>().text = _ddol.translates.translation["login.placeholder.email"];
            loginMenuPlaceholderPassword.GetComponent<Text>().text = _ddol.translates.translation["login.placeholder.password"];
            loginMenuLogin.GetComponent<Text>().text = _ddol.translates.translation["login.ValidLogin"];
            loginMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["login.returnToMainPage"];
            
            editorMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["editor.quitEditorMenu"];
            editorMenuRunEditor.GetComponent<Text>().text = _ddol.translates.translation["editor.createNewMap"];
            
            createAccountMenuTitle.GetComponent<Text>().text = _ddol.translates.translation["newAccount.title"];
            createAccountMenuPlaceholderEmail.GetComponent<Text>().text = _ddol.translates.translation["newAccount.placeholder.email"];
            createAccountMenuPlaceholderPassword.GetComponent<Text>().text = _ddol.translates.translation["newAccount.placeholder.password"];
            createAccountMenuPlaceholderValidPassword.GetComponent<Text>().text = _ddol.translates.translation["newAccount.placeholder.validPassword"];
            createAccountMenuCreate.GetComponent<Text>().text = _ddol.translates.translation["newAccount.ValidCreateAccount"];
            createAccountMenuQuit.GetComponent<Text>().text = _ddol.translates.translation["newAccount.returnToMainPage"];

            foreach (var field in listNetworks)
            {
                field.GetComponent<Text>().text = _ddol.translates.translation["network.noNetworkMessage"];
            }
        }
    }
}
