using UnityEngine;
using UnityEngine.UI;

namespace EndGameScripts
{
    public class EndGameScript : MonoBehaviour
    {

        public GameObject loseCanvas;
        public GameObject winCanvas;
        
        void Start()
        {
            var ddol = GameObject.Find("Preload").GetComponent<DDOL>();

            if (ddol.gameData.isVictory)
            {
                DisplayTimer(ddol.gameData.timer);
                winCanvas.SetActive(true);
            }
            else
            {
                loseCanvas.SetActive(true);
            }
        }

        private void DisplayTimer(float timerInSeconds)
        {
            var timerMinute = Mathf.FloorToInt(timerInSeconds / 60) < 0 ? 0 : Mathf.FloorToInt(timerInSeconds / 60);
            var timerSeconds = Mathf.FloorToInt(timerInSeconds % 60) < 0 ? 0 : Mathf.FloorToInt(timerInSeconds % 60);
            
            var test = loseCanvas.transform.Find("Title").GetComponent<Text>();
            test.text = $"{test.text} en {timerMinute} minutes et {timerSeconds} Seconds";
        }
    }
}
