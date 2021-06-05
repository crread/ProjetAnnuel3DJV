using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Game.Minions;
using UnityEngine.AI;
using Script.Modules;

>>>>>>> origin/tb_dev3

namespace Game
{
    public class Player : MonoBehaviour
    {
        public Transform playerTransform;
<<<<<<< HEAD

        public int fireMinionsFollowing = 0;
        public int airMinionsFollowing = 0;
        public int earthMinionsFollowing = 0;
        public int waterMinionsFollowing = 0;

        public int currentId;
=======
        public List<Collider> groundCollider = new List<Collider>();
        public Camera raycastCamera;
        public Text fireMinionsTargeted;
        public Text airMinionsTargeted;
        public Text earthMinionsTargeted;
        public Text waterMinionsTargeted;

        public Animator characterAnimator;
        private readonly Dictionary<string, List<GameObject>> _minionsListType = new Dictionary<string, List<GameObject>>();
        private readonly Dictionary<string, List<GameObject>> _minionsListTypeFollowing = new Dictionary<string, List<GameObject>>();
        private readonly Dictionary<string, List<GameObject>> _minionsListBufferForFlag = new Dictionary<string, List<GameObject>>();
        public bool _disableMove = false;
        public Game game;
        private Vector3 _lastHit;
        
        private void Start()
        {
            _minionsListType.Add("air", new List<GameObject>());
            _minionsListType.Add("fire", new List<GameObject>());
            _minionsListType.Add("water", new List<GameObject>());
            _minionsListType.Add("earth", new List<GameObject>());
        
            _minionsListTypeFollowing.Add("air", new List<GameObject>());
            _minionsListTypeFollowing.Add("fire", new List<GameObject>());
            _minionsListTypeFollowing.Add("water", new List<GameObject>());
            _minionsListTypeFollowing.Add("earth", new List<GameObject>());
            
            
        }

        private void Update()
        {
            
            
                if (Input.GetMouseButton(0) && !_disableMove )
                {
                    var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
                    foreach (var ground in groundCollider)
                    {
                        if (ground.Raycast(ray, out var hit, float.MaxValue))
                        {
                            targetAgent.SetDestination(hit.point);
                            _lastHit = hit.point;
                            characterAnimator.SetBool("isRunning", true);
                            characterAnimator.SetBool("isPointing", false);
                            break;
                        }
                    }
            
            
                }
            

            if (Vector3.Distance(_lastHit, playerTransform.position)<=1.1)
            {
                characterAnimator.SetBool("isRunning", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            { 
                MakeMinionsFollow();
            }
            
        }

        public void UpdateMoveOption(bool option)
        {
            _disableMove = option;
        }
    
        private void MakeMinionsFollow()
        {
            foreach (var minionList in _minionsListType)
            {
                foreach (var minion in minionList.Value)
                {
                    if (!_minionsListTypeFollowing[minionList.Key].Contains(minion))
                    {
                          
                        
                            MinionModule minionScript = minion.GetComponent<MinionModule>();
                            minionScript.ObjectToFollow = playerTransform;
                            minionScript.Follow = true;
                            _minionsListTypeFollowing[minionList.Key].Add(minion);
                        
                        
                    }
                }
            }
            UpdateFieldText();
        }
>>>>>>> origin/tb_dev3

        private void Start()
        {
            currentId = GetInstanceID();
        }

        public void ResetMaxFollowing()
        {
<<<<<<< HEAD
            earthMinionsFollowing = 0;
            airMinionsFollowing = 0;
            waterMinionsFollowing = 0;
            fireMinionsFollowing = 0;
=======
            
            var minionsType = minion.GetComponent<MinionModule>().TypeMinion;

            if (_minionsListType[minionsType].Contains(minion))
            {
                if (minion.GetComponent<MinionModule>().Follow)
                {
                    _minionsListTypeFollowing[minionsType].Remove(minion);
                }
                _minionsListType[minionsType].Remove(minion);
            }
>>>>>>> origin/tb_dev3
        }

        public void AddMinions(string typeMinion)
        {
<<<<<<< HEAD
            switch (typeMinion)
=======
            var minionsType = minion.GetComponent<MinionModule>().TypeMinion;
        
            if (!_minionsListType[minionsType].Contains(minion))
>>>>>>> origin/tb_dev3
            {
                case "fire":
                    fireMinionsFollowing += 1;
                    break;
                case "water":
                    waterMinionsFollowing += 1;
                    break;
                case "earth":
                    earthMinionsFollowing += 1;
                    break;
                case "air":
                    airMinionsFollowing += 1;
                    break;
            }
        }

        public void MinusMinions(string typeMinion)
        {
            switch (typeMinion)
            {
<<<<<<< HEAD
                case "fire":
                    fireMinionsFollowing -= 1;
                    break;
                case "water":
                    waterMinionsFollowing -= 1;
                    break;
                case "earth":
                    earthMinionsFollowing -= 1;
                    break;
                case "air":
                    airMinionsFollowing -= 1;
                    break;
=======
                foreach (var minion in minionList.Value.ToList())
                {
                    if (_minionsListBufferForFlag[minionList.Key].Contains(minion))
                    {
                        minion.GetComponent<MinionModule>().ObjectToFollow = flag.transform;
                        _minionsListTypeFollowing[minionList.Key].Remove(minion);
                        _minionsListBufferForFlag[minionList.Key].Remove(minion);
                    }
                }
>>>>>>> origin/tb_dev3
            }
        }

        

       
    }
}