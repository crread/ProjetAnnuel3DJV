using UnityEngine;

namespace Game
{
    public class RockCollisionTrigger : MonoBehaviour
    {
        public Collider objectToTrigger;
        public bool boxTriggered = false;
        private void OnTriggerEnter(Collider element)
        {
            if (element.Equals(objectToTrigger))
            {
                boxTriggered = true;
            }
        }
    }
}
