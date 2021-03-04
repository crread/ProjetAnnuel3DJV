using UnityEngine;
using UnityEngine.UI;

namespace Scenes.MainMenu
{
    public class MouseHover : MonoBehaviour
    {
        public GameObject Button;

        private Text _text;

        private void Start()
        {
            _text = Button.GetComponent<Text>();
        }

        private void OnMouseOver()
        {
            Debug.Log("test hover");
        }

        private void OnMouseEnter()
        {
            Debug.Log("test");
            _text.color = Color.red;
        }

        private void OnMouseExit()
        {
            _text.color = new Color(0.6980392f, 0.4823529f, 0.4823529f);
        }
    }
}
