using UnityEngine;
using UnityEngine.UI;

namespace Translates
{
    public class GameTranslate : MonoBehaviour
    {
        public GameObject QuitButton;
        public GameObject RestartButton;
        public GameObject ContinuButton;

        private DDOL _ddol;
        void Start()
        {
            _ddol = GameObject.Find("Preload").GetComponent<DDOL>();
            
            QuitButton.GetComponent<Text>().text = _ddol.translates.translation["game.menu.keepPlaying"];
            RestartButton.GetComponent<Text>().text = _ddol.translates.translation["game.menu.restartGame"];
            ContinuButton.GetComponent<Text>().text = _ddol.translates.translation["game.menu.quitGame"];
        }
    }
}
