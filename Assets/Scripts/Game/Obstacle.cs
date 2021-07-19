using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Obstacle : MonoBehaviour
    {
        public GameObject mainCamera;
        
        public List<Switch.Switch> switchs = new List<Switch.Switch>();
        public List<TriggerAreaCollision> boxTriggers = new List<TriggerAreaCollision>();
        public enum ListOfInteraction {PlayAnimation, ActiveGravity};
        public ListOfInteraction typeInteraction;
        public bool isActionCameraOn;
        public GameObject camera;
        
        private bool _triggeredSwitch = true;
        private bool _triggeredTrigger = true;
        private bool _cutsceneTriggered = false;
        private bool _isTriggered;
        private Animator _selfAnimation;
        private Rigidbody _selfRigidbody;

        private void Start()
        {
            switch (typeInteraction)
            {
                case ListOfInteraction.PlayAnimation:
                    _selfAnimation = GetComponent<Animator>();
                    break;
                case ListOfInteraction.ActiveGravity:
                    _selfRigidbody = GetComponent<Rigidbody>();
                    _selfRigidbody.useGravity = false;
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
            if (_selfAnimation)
            {
                if (_isTriggered)
                {
                    if (_selfAnimation.GetCurrentAnimatorStateInfo(0).IsName("DoorOpened") && isActionCameraOn)
                    {
                        ActionStopCutScene();
                    }
                    
                    if (isActionCameraOn && !_cutsceneTriggered)
                        ActionActiveCutScene();
                    _selfAnimation.SetTrigger("OpenDoor");
                }
                else
                {
                    _selfAnimation.SetTrigger("CloseDoor");
                }
            }
        }
        
        private void ActiveGravity()
        {
            if (_selfRigidbody && _isTriggered)
            {
                _selfRigidbody.useGravity = true;
            }
        }

        private void ActionActiveCutScene()
        {
            camera.SetActive(true);
            mainCamera.SetActive(false);
        }

        private void ActionStopCutScene()
        {
            _cutsceneTriggered = true;
            mainCamera.SetActive(true);
            camera.SetActive(false);
            
        }
    }
}
