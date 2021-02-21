using UnityEngine;

namespace Game.Flag
{
    public class FlagEventCollider : MonoBehaviour
    {
        public Flag flag;

        private void OnTriggerExit(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                flag.RemoveMinion(minion.gameObject);
            }
        }
    }
}
