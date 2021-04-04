using UnityEngine;
using UnityEngine.Events;

namespace Game.Switch
{
    public class ColliderSwitchOut : MonoBehaviour
    {
        public Switch switchButton;

        private void OnTriggerExit(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                switchButton.RemoveMinionInArea(minion.gameObject);
            }
        }
    }
}
