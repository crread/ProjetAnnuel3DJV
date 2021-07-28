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
        private float _stopFollowingPlayer = 5f;
        private float _stopFollowingFlag = 2f;
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
            _navMeshAgent.stoppingDistance = _stopFollowingPlayer;
            _navMeshAgent.autoRepath = false;
            _navMeshAgent.radius = 0.55f;
        }

        private void FixedUpdate()
        {
            if (positionObjectToFollow != null)
            {
                var distanceBetween = Vector3.Distance(minion.position, positionObjectToFollow.position);

                if (distanceBetween >= _navMeshAgent.stoppingDistance)
                {
                    _navMeshAgent.SetDestination(positionObjectToFollow.position);
                    gameObject.transform.rotation =
                        Quaternion.LookRotation(Vector3.Normalize(positionObjectToFollow.position));
                    _navMeshAgent.isStopped = false;
                }
                else
                {
                    _navMeshAgent.velocity = Vector3.zero;
                    _navMeshAgent.SetDestination(transform.position);
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
            
            if (positionObjectToFollow.gameObject.CompareTag($"flag"))
                _navMeshAgent.stoppingDistance = _stopFollowingFlag;
            else
                _navMeshAgent.stoppingDistance = _stopFollowingPlayer;
            
        }
    }
}