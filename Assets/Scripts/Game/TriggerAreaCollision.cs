using System;
using UnityEngine;

namespace Game
{
    public class TriggerAreaCollision : MonoBehaviour
    {
        public Collider objectToTrigger;
        public bool boxTriggered;

        private void Start()
        {
            boxTriggered = false;
        }

        private void OnTriggerEnter(Collider element)
        {
            if (element.Equals(objectToTrigger))
            {
                boxTriggered = true;
            }
        }
    }
}
