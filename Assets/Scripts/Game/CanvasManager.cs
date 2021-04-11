using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CanvasManager : MonoBehaviour
    {
        public Text timer;
        public GameObject airSelectedBackground;
        public GameObject earthSelectedBackground;
        public GameObject waterSelectedBackground;
        public GameObject fireSelectedBackground;
        public MinionSelectorField airField;
        public MinionSelectorField earthField;
        public MinionSelectorField fireField;
        public MinionSelectorField waterField;
        
        private int _timerMinutesLeft;
        private int _timerSecondsLeft;
        
        private void Start()
        {
            SetBackgroundFieldsToFalse();
        }

        public void FieldSelected(string type)
        {
            SetBackgroundFieldsToFalse();
            switch (type)
            {
                case "fire":
                    fireSelectedBackground.SetActive(true);
                    break;
                case "water":
                    waterSelectedBackground.SetActive(true);
                    break;
                case "earth":
                    earthSelectedBackground.SetActive(true);
                    break;
                case "air":
                    airSelectedBackground.SetActive(true);
                    break;
            }
        }
        
        public void DisplayTimer(float timerInSeconds)
        {
            _timerMinutesLeft = Mathf.FloorToInt(timerInSeconds / 60) < 0 ? 0 : Mathf.FloorToInt(timerInSeconds / 60);
            _timerSecondsLeft = Mathf.FloorToInt(timerInSeconds % 60) < 0 ? 0 : Mathf.FloorToInt(timerInSeconds % 60);
            timer.text = $"{_timerMinutesLeft:00}:{_timerSecondsLeft:00}";
        }

        public void SetBackgroundFieldsToFalse()
        {
            airSelectedBackground.SetActive(false);
            earthSelectedBackground.SetActive(false);
            waterSelectedBackground.SetActive(false);
            fireSelectedBackground.SetActive(false);
        }
    }
}
