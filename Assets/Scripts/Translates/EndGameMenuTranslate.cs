using System;
using UnityEngine;
using UnityEngine.UI;

namespace Translates
{
    public class EndGameMenuTranslate : MonoBehaviour
    {
        public GameObject winTitle;
        public GameObject loseTitle;
        public GameObject replayButtonLose;
        public GameObject quitButtonLose;
        public GameObject replayButtonWin;
        public GameObject quitButtonWin;
        
        private DDOL _ddol;
        
        private void Start()
        {
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            
            winTitle.GetComponent<Text>().text = _ddol.translates.translation["game.endGame.win.title"];
            loseTitle.GetComponent<Text>().text = _ddol.translates.translation["game.endGame.lose.title"];
            replayButtonLose.GetComponent<Text>().text = _ddol.translates.translation["game.endGame.restart"];
            quitButtonLose.GetComponent<Text>().text = _ddol.translates.translation["game.endGame.quit"];
            replayButtonWin.GetComponent<Text>().text = _ddol.translates.translation["game.endGame.restart"];
            quitButtonWin.GetComponent<Text>().text = _ddol.translates.translation["game.endGame.quit"];
        }
    }
}
