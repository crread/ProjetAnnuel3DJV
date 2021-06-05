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

        private Collider _agentCollider;

        private float _stop_following = 5f;
        
        private Vector3 _velocity;

        private NavMeshAgent _navMeshAgent;
        
        // test boid

        public Vector3 position;
        public Vector3 velocity;
        public List<Minion> neighbors;

        private Game _gameManagerScript;

        private void Awake()
        {
            _gameManagerScript = GameObject.Find("Scripts").GetComponent<Game>();
            _agentCollider = GetComponent<Collider>();
            velocity = Vector3.zero;
            position = gameObject.transform.position;
        }

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.stoppingDistance = _stop_following;
        }

        private void UpdateNeighbors()
        {
            Collider[] listCollider = Physics.OverlapSphere(position, 2, LayerMask.GetMask("Minion"));
            neighbors.Clear();

            foreach (var collider in listCollider)
            {
                var script = collider.GetComponent<Minion>();

                if (script.GetInstanceID() != GetInstanceID())
                    neighbors.Add(script);
            }
        }

        public Vector3 Seek(Transform target, float weight)
        {
            if (weight < 0.0001f)
                return Vector3.zero;

            var desiredVelocity = Vector3.Normalize(target.position - position) * weight;
            return desiredVelocity - velocity;
        }

        private Vector3 Separation(float steps, float weight)
        {
            var c = Vector3.zero;

            foreach (var boid in neighbors)
            {
                var distance = Vector3.Distance(position, boid.position);
                c = c + Vector3.Normalize(position - boid.position) / Mathf.Pow(distance, 2) / steps;
            }
            
            return c * weight;
        }

        private Vector3 Alignement(float weight)
        {
            Vector3 pv = Vector3.zero;

            if (neighbors.Count == 0)
                return pv;

            foreach (var boid in neighbors)
            {
                pv = pv + boid.velocity;
            }

            if (neighbors.Count > 1)
            {
                pv /= (neighbors.Count);
            }

            return Vector3.Normalize(pv - velocity) * weight;
        }
        
        private Vector3 LimitVelocity(Vector3 v, float limit)
        {
            if (v.magnitude > limit)
            {
                v = v / v.magnitude * limit;
            }
            return v;
        }
        
        private Vector3 Cohesion(float steps, float weight)
        {
            var pc = Vector3.zero;

            if (neighbors.Count == 0) 
                return pc;

            foreach (var boid in neighbors)
            {
                if (pc == Vector3.zero)
                {
                    pc = boid.position;
                }
                else
                {
                    pc += boid.position;
                }
            }
            
            pc /= neighbors.Count;
            
            return (pc - position) / steps * weight;
        }

        private Vector3 LimitRotation(Vector3 v, float maxAngle, float maxSpeed)
        {
            return Vector3.RotateTowards(velocity, v, maxAngle * Mathf.Deg2Rad, maxSpeed);
        }

        private void Update()
        {
            if (positionObjectToFollow != null)
            {
                var distanceBetween = Vector3.Distance(minion.position, positionObjectToFollow.position);
                if (distanceBetween > 4.99f)
                {
                    UpdateNeighbors();
                    var separationVector = Separation(1f, 10f);
                    var alignementVector = Alignement(10f);
                    var cohesionVector = Cohesion(1f, 10f);
                    var seekVector = Seek(positionObjectToFollow, 10f);
                    var localVelocity = velocity + separationVector + alignementVector + seekVector + cohesionVector;
                    localVelocity = LimitVelocity(localVelocity, 10f);
                    localVelocity = LimitRotation(localVelocity, 15f, 1f);
                    position += localVelocity;
                    velocity = localVelocity;
                    // gameObject.transform.position = position;
                    // GetComponent<NavMeshAgent>().velocity = velocity;
                    _navMeshAgent.destination = positionObjectToFollow.position;
                    // gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
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

        private void UpdatePosition()
        {
            var distanceBetween = Vector3.Distance(minion.position, positionObjectToFollow.position);
            if (distanceBetween > 4f)
            {
                var positionObjectTofollow = positionObjectToFollow.position;
                transform.position =
                    Vector3.SmoothDamp(transform.position, positionObjectTofollow, ref _velocity, 1f, _speed);
                // GetComponent<NavMeshAgent>().destination = positionObjectToFollow.position;
            }
        }
    }
}