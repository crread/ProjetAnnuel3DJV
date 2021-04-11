using UnityEngine;

namespace Game.Minions
{
    public class Minion : MonoBehaviour
    {
        public Transform minion;
        public Transform objectToFollow;
        public int instanceIdObjectToFollow;
        public string typeMinion;
        public Rigidbody rb;

        public void ChangePosition(Transform newObjectToFollowPosition)
        {
            objectToFollow = newObjectToFollowPosition;
        }
        
        private void FixedUpdate()
        {
            if (objectToFollow != null)
            {
                UpdatePosition();
            }
        }
        
        private void UpdatePosition()
        {
            if (Vector3.Distance(minion.position, objectToFollow.position) > 4f)
            {
                transform.position = Vector3.MoveTowards(minion.position, objectToFollow.position, 0.13f);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}