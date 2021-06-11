using UnityEngine;

namespace Game.Minions
{
    public class TriggerDetectionOutRangeMinion : MonoBehaviour
    {
        public Player playerScript;
        public Game gameScript;
        private void OnTriggerExit(Collider minion)
        {
            var minionScript = minion.GetComponent<Minion>();
            
            if (minion.gameObject.CompareTag($"minion") && minionScript.instanceIdObjectToFollow == playerScript.currentId)
            {
                minionScript.positionObjectToFollow = null;
                minionScript.instanceIdObjectToFollow = 0;
                playerScript.MinusMinions(minionScript.typeMinion);
                gameScript.UpdateFieldsMaximumCanvas();
            }
        }
    }
}
