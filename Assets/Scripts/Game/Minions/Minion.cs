using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Minions
{
    public class Minion : MonoBehaviour
    {
        public Transform minion;
        public Transform positionObjectToFollow = null;
        public int instanceIdObjectToFollow;
        public string typeMinion;
        
        private float _speed = 10f;

        private float _stop_following = 3f;
        
        private Vector3 _velocity;

        private NavMeshAgent _navMeshAgent;

        private Game _gameManagerScript;

        private void Awake()
        {
            _gameManagerScript = GameObject.Find("Scripts").GetComponent<Game>();
        }

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.stoppingDistance = _stop_following;
            _navMeshAgent.autoRepath = true;
            _navMeshAgent.radius = 0.5f;
        }

        private void Update()
        {
            if (positionObjectToFollow != null)
            {
                var distanceBetween = Vector3.Distance(minion.position, positionObjectToFollow.position);
                if (distanceBetween > _navMeshAgent.stoppingDistance)
                {
                    _navMeshAgent.SetDestination(positionObjectToFollow.position);
                    _navMeshAgent.isStopped = false;
                    gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(positionObjectToFollow.position));
                }
                else
                {
                    _navMeshAgent.isStopped = true;
                }
            }
        }

        public void SetPositionObjectToFollow(int instanceNewObjectToFollow, Transform newObjectToFollow)
        {
            if (positionObjectToFollow != null && instanceIdObjectToFollow != instanceNewObjectToFollow)
            {
                if (positionObjectToFollow.gameObject.CompareTag($"flag"))
                {
                    _gameManagerScript.RemoveMinionFromFlag(positionObjectToFollow.gameObject.GetComponent<Flag.Flag>(),
                        typeMinion);
                }
            }

            positionObjectToFollow = newObjectToFollow;
            instanceIdObjectToFollow = instanceNewObjectToFollow;
        }
    }
}