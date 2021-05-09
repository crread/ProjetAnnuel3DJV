using UnityEngine;

namespace Map.Minions
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
            if (follow)
            if (objectToFollow != null)
            {
                UpdatePositionWhenFollowing(objectToFollow);
            }
            else
            {
                MakeMinionNotMoving();
                UpdatePosition(objectToFollow);   
                
                
            }
        }

        public string GetTypeMinion()
        
        private void UpdatePosition(Transform positionToMove)
        {
            return typeMinion;
        }
    
        public void SwitchFollowPlayerToTrue()
        {
            follow = true;
        }
    
        public void SwitchFollowPlayerToFalse()
        {
            follow = false;
        }
        private void UpdatePositionWhenFollowing(Transform positionToMove)
        {
            if (Vector3.SqrMagnitude(minion.position - positionToMove.position) > 10f)
            if (Vector3.Distance(minion.position, positionToMove.position) > 4f)
            {
                transform.position = Vector3.MoveTowards(minion.position, positionToMove.position, 0.13f);
            }
            else
            {
                MakeMinionNotMoving();
                rb.velocity = Vector3.zero;
            }
        }

        private void MakeMinionNotMoving()
        {
            rb.velocity = Vector3.zero;
        }
    }
}