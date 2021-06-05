using UnityEngine;

namespace Game.Minions
{
    public class Minion : MonoBehaviour
    {
        public Transform minion;
        public Transform positionObjectToFollow = null;
        public int instanceIdObjectToFollow;
        public string typeMinion;
        private float _speed = 10f;
        private Vector3 _velocity = Vector3.zero;
        
        private Game _gameManagerScript;

        private void Awake()
        {
            _gameManagerScript = GameObject.Find("Scripts").GetComponent<Game>();
        }
        private void Update()
        {
            if (positionObjectToFollow != null)
            {
                UpdatePosition();
            } 
        }

        public void SetPositionObjectToFollow(int instanceNewObjectToFollow, Transform newObjectToFollow)
        {
            if (positionObjectToFollow != null && instanceIdObjectToFollow != instanceNewObjectToFollow)
            {
                if (positionObjectToFollow.gameObject.CompareTag($"flag"))
                {
                    _gameManagerScript.RemoveMinionFromFlag(positionObjectToFollow.gameObject.GetComponent<Flag.Flag>(), typeMinion);
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
                transform.position = Vector3.SmoothDamp(transform.position, positionObjectTofollow, ref _velocity , 1f, _speed);
            }
        }
    }
}