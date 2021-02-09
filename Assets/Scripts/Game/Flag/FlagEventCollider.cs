using UnityEngine;

namespace Map.Flag
{
    public class FlagEventCollider : MonoBehaviour
    {
        public global::Game.Flag.Flag flag;

        private void OnCollisionExit(Collision minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                flag.RemoveMinion(minion.gameObject);
            }
        }
    }
}
