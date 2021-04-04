using Game;
using UnityEngine;

namespace Map.Minions
{
    public class TriggerDetectionOutRangeMinion : MonoBehaviour
    {
        public Player playerScript;
    
        private void OnTriggerExit(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                playerScript.RemoveMinionInArea(minion.gameObject);
            }
        }
    }
}
