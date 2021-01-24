using UnityEngine;
using Random = UnityEngine.Random;

namespace MinionScripts
{
    public class Minion : MonoBehaviour
    {
        public bool followPlayer = false;
        public Transform minion;
        public Transform player;
        public string typeMinion;

        private void FixedUpdate()
        {
            if (followPlayer)
            {
                UpdatePosition();
            }
        }

        public string GetTypeMinion()
        {
            return typeMinion;
        }
    
        public void SwitchFollowPlayerToTrue()
        {
            followPlayer = true;
        }
    
        public void SwitchFollowPlayerToFalse()
        {
            followPlayer = false;
        }
        private void UpdatePosition()
        {
            if (Vector3.SqrMagnitude(minion.position - player.position) > 4f)
            {
                minion.position = Vector3.MoveTowards(minion.position, player.position, Time.deltaTime + 0.01f);   
            }
        }
    }
}
