using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Game.Minions;
using UnityEngine.AI;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public NavMeshAgent targetAgent;
        public Transform playerTransform;

        public int fireMinionsFollowing = 0;
        public int airMinionsFollowing = 0;
        public int earthMinionsFollowing = 0;
        public int waterMinionsFollowing = 0;

        public int currentId;
        private void Start()
        {
            currentId = GetInstanceID();
        }

        public void ResetMaxFollowing()
        {
            earthMinionsFollowing = 0;
            airMinionsFollowing = 0;
            waterMinionsFollowing = 0;
            fireMinionsFollowing = 0;
        }

        public void AddMinions(string typeMinion)
        {
            switch (typeMinion)
            {
                case "fire":
                    fireMinionsFollowing += 1;
                    break;
                case "water":
                    waterMinionsFollowing += 1;
                    break;
                case "earth":
                    earthMinionsFollowing += 1;
                    break;
                case "air":
                    airMinionsFollowing += 1;
                    break;
            }
        }
        
        public void MinusMinions(string typeMinion)
        {
            switch (typeMinion)
            {
                case "fire":
                    fireMinionsFollowing -= 1;
                    break;
                case "water":
                    waterMinionsFollowing -= 1;
                    break;
                case "earth":
                    earthMinionsFollowing -= 1;
                    break;
                case "air":
                    airMinionsFollowing -= 1;
                    break;
            }
        }
    }
}