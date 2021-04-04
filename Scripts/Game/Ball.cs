using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Ball : MonoBehaviour
    {
        public List<Switch.Switch> switchs = new List<Switch.Switch>();
        public List<RockCollisionTrigger> boxTrigger = new List<RockCollisionTrigger>();
        
        private int _openingDoorToTrue = 0;
        private int _allElementsToTrigger = 0;
        private Rigidbody _selfRigidbody;
        void Start()
        {
            _allElementsToTrigger = switchs.Count + boxTrigger.Count;
            _selfRigidbody = this.GetComponent<Rigidbody>();
            _selfRigidbody.useGravity = false;
        }
        
        void Update()
        {
            _openingDoorToTrue = 0;
            
            if (switchs.Count > 0)
            {
                foreach (var element in switchs.Where(element => element.enoughMinion))
                {
                    _openingDoorToTrue += 1;
                }
            }
            if (boxTrigger.Count > 0)
            {
                foreach (var element in boxTrigger.Where(element => element.boxTriggered))
                {
                    _openingDoorToTrue += 1;
                }
            }
        }
        
        private void FixedUpdate()
        {
            if (_openingDoorToTrue == _allElementsToTrigger)
            {
                _selfRigidbody.useGravity = true;
            }
        }
    }
}
