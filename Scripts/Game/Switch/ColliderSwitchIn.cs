using UnityEngine;
using UnityEngine.Events;

namespace Game.Switch
{
    public class ColliderSwitchIn : MonoBehaviour
    {
        public Switch switchButton;

        private void OnTriggerEnter(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                switchButton.AddMinionInArea(minion.gameObject);
            }
        }
    }
}
