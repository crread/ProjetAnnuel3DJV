using UnityEngine;

namespace Game.Minions
{
    public class Minion : MonoBehaviour
    {
        public bool follow = false;
        public Transform minion;
        public Transform objectToFollow;
        public string typeMinion;
        public Rigidbody rb;

        private void FixedUpdate()
        {
            if (objectToFollow != null)
            {
                UpdatePosition(objectToFollow);   
                
                
            }
        }
        
        private void UpdatePosition(Transform positionToMove)
        {
            if (Vector3.Distance(minion.position, positionToMove.position) > 4f)
            {
                transform.position = Vector3.MoveTowards(minion.position, positionToMove.position, 0.13f);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}