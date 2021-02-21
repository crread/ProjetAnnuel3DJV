using UnityEngine;

namespace Scenes.MainMenu
{
    public class MouseHover : MonoBehaviour
    {
        public TextMesh text;
        void Start()
        {
            text.color = new Color(0.6980392f, 0.4823529f, 0.4823529f);
        }

        public void OnMouseEnter()
        {
            text.color = Color.red;
        }

        public void OnMouseExit()
        {
            text.color = new Color(0.6980392f, 0.4823529f, 0.4823529f);
        }
    }
}
