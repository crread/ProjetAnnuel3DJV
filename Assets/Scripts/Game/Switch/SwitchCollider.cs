using UnityEngine;
using UnityEngine.AI;

namespace Game.Switch
{
    public class SwitchCollider : MonoBehaviour
    {
        public Switch switchButton;
        private void OnTriggerExit(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                switchButton.RemoveMinionInArea(minion.gameObject);
            }
        }
        private void OnTriggerEnter(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                switchButton.AddMinionInArea(minion.gameObject);
            }
        }
    }
}
