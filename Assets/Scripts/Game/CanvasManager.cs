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
        
        public GameObject airSelectedBackgroundFlag;
        public GameObject earthSelectedBackgroundFlag;
        public GameObject waterSelectedBackgroundFlag;
        public GameObject fireSelectedBackgroundFlag;
        public MinionSelectorField airFieldFlag;
        public MinionSelectorField earthFieldFlag;
        public MinionSelectorField fireFieldFlag;
        public MinionSelectorField waterFieldFlag;

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
                case "fireFlag":
                    fireSelectedBackgroundFlag.SetActive(true);
                    break;
                case "waterFlag":
                    waterSelectedBackgroundFlag.SetActive(true);
                    break;
                case "earthFlag":
                    earthSelectedBackgroundFlag.SetActive(true);
                    break;
                case "airFlag":
                    airSelectedBackgroundFlag.SetActive(true);
                    break;
            }
        }
        
        public void DisplayTimer(float timerInSeconds)
        {
            var timerMinutesLeft = Mathf.FloorToInt(timerInSeconds / 60) < 0 ? 0 : Mathf.FloorToInt(timerInSeconds / 60);
            var timerSecondsLeft = Mathf.FloorToInt(timerInSeconds % 60) < 0 ? 0 : Mathf.FloorToInt(timerInSeconds % 60);
            timer.text = $"{timerMinutesLeft:00}:{timerSecondsLeft:00}";
        }

        public void SetBackgroundFieldsToFalse()
        {
            airSelectedBackground.SetActive(false);
            earthSelectedBackground.SetActive(false);
            waterSelectedBackground.SetActive(false);
            fireSelectedBackground.SetActive(false);
            airSelectedBackgroundFlag.SetActive(false);
            earthSelectedBackgroundFlag.SetActive(false);
            waterSelectedBackgroundFlag.SetActive(false);
            fireSelectedBackgroundFlag.SetActive(false);
        }
    }
}
