using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {
        public List<Switch.Switch> switchs = new List<Switch.Switch>();
        public List<RockCollisionTrigger> boxTrigger = new List<RockCollisionTrigger>();
        
        private int _openingDoorToTrue = 0;
        private int _allElementsToTrigger = 0;
        private Animator _animation;
        private void Start()
        {
            _animation = this.GetComponent<Animator>();
            _allElementsToTrigger = switchs.Count + boxTrigger.Count;
        }

        private void Update()
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
                _animation.SetTrigger("OpenDoor");
            }
            else
            {
                _animation.SetTrigger("CloseDoor");
            }
        }
    }
}
