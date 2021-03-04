using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.MainMenu
{
    public class EventSystemScript : MonoBehaviour, IPointerEnterHandler
    {
        private void Update()
        {
            /*
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log(EventSystem.current.);
            }
            */
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                Debug.Log("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.name);
            }
        }
    }
}
