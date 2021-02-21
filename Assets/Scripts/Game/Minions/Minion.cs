using UnityEngine;

namespace Map.Minions
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
            {
                UpdatePositionWhenFollowing(objectToFollow);
            }
            else
            {
                MakeMinionNotMoving();
            }
        }

        public string GetTypeMinion()
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
            {
                transform.position = Vector3.MoveTowards(minion.position, positionToMove.position, 0.13f);
            }
            else
            {
                MakeMinionNotMoving();
            }
        }

        private void MakeMinionNotMoving()
        {
            rb.velocity = Vector3.zero;
        }
    }
}