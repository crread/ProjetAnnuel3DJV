﻿using UnityEngine;

namespace Game.Minions
{
    public class TriggerDetectionInRangeMinion : MonoBehaviour
    {
        public Player playerScript;
        private void OnTriggerEnter(Collider minion)
        {
            if (minion.gameObject.CompareTag($"minion"))
            {
                playerScript.AddMinionInArea(minion.gameObject);
            }
        }
    }
}
