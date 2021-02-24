using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Obstacle : MonoBehaviour
    {
        public List<Switch.Switch> switchs = new List<Switch.Switch>();
        public List<TriggerAreaCollision> boxTriggers = new List<TriggerAreaCollision>();
        public enum ListOfInteraction {PlayAnimation, ActiveGravity};
        public ListOfInteraction typeInteraction;
        
        private bool _triggeredSwitch = true;
        private bool _triggeredTrigger = true;
        private bool _isTriggered;
        private Animator _selfAnimation;
        private Rigidbody _selfRigidbody;
        
        private void Start()
        {
            switch (typeInteraction)
            {
                case ListOfInteraction.PlayAnimation:
                    if (GetComponent<Animator>() != null)
                    {
                        _selfAnimation = GetComponent<Animator>();   
                    }
                    break;
                case ListOfInteraction.ActiveGravity:
                    if (GetComponent<Rigidbody>() != null)
                    {
                        _selfRigidbody = GetComponent<Rigidbody>();
                        _selfRigidbody.useGravity = false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Update()
        {
            if (switchs.Count > 0)
            {
                _triggeredSwitch = switchs.All(element => element.enoughMinion);
            }
            if (boxTriggers.Count > 0)
            {
                _triggeredTrigger = boxTriggers.All(element => element.boxTriggered);
            }
            _isTriggered = _triggeredSwitch & _triggeredTrigger;
        }

        private void FixedUpdate()
        {
            ControlObstacle();
        }

        private void ControlObstacle()
        {
            switch (typeInteraction)
            {
                case ListOfInteraction.PlayAnimation:
                    PlayAnimation();
                    break;
                case ListOfInteraction.ActiveGravity:
                    ActiveGravity();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void PlayAnimation()
        {
            if (_selfAnimation != null)
            {
                _selfAnimation.SetTrigger(_isTriggered ? "OpenDoor" : "CloseDoor");   
            }
        }
        
        private void ActiveGravity()
        {
            if (_selfRigidbody != null && _isTriggered)
            {
                _selfRigidbody.useGravity = true;   
            }
        }
    }
}
