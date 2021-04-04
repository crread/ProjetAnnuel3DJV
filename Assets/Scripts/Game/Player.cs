using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Game.Minions;
using UnityEngine.AI;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public NavMeshAgent targetAgent;
        public Transform playerTransform;
        public List<Collider> groundCollider = new List<Collider>();
        public Camera raycastCamera;
        public Text fireMinionsTargeted;
        public Text airMinionsTargeted;
        public Text earthMinionsTargeted;
        public Text waterMinionsTargeted;
        
        public Animator characterAnimator;
        private bool _isRunning;
        private readonly Dictionary<string, List<GameObject>> _minionsListType = new Dictionary<string, List<GameObject>>();
        private readonly Dictionary<string, List<GameObject>> _minionsListTypeFollowing = new Dictionary<string, List<GameObject>>();
        private readonly Dictionary<string, List<GameObject>> _minionsListBufferForFlag = new Dictionary<string, List<GameObject>>();
        private bool _disableMove = false;
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
            
            _isRunning = false;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && !_disableMove)
            {
                var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
                foreach (var ground in groundCollider)
                {
                    if (ground.Raycast(ray, out var hit, float.MaxValue))
                    {
                        targetAgent.SetDestination(hit.point);
                        characterAnimator.SetBool("isRunning", true);
                        break;
                    }
                    else
                    {
                        characterAnimator.SetBool("isRunning", false);
                        break;
                    }
                }
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
                        Minion minionScript = minion.GetComponent<Minion>();
                        minionScript.objectToFollow = playerTransform;
                        _minionsListTypeFollowing[minionList.Key].Add(minion);   
                    }
                }
            }
            UpdateFieldText();
        }

        public void LoadMinionBuffer(Dictionary<string, int> minionsSelected)
        {
            InitMinionsListBuffer();
            foreach (var typeList in _minionsListBufferForFlag.ToList())
            {
                if (_minionsListTypeFollowing[typeList.Key].Any() && minionsSelected[typeList.Key] > 0)
                {
                    _minionsListBufferForFlag[typeList.Key] = _minionsListTypeFollowing[typeList.Key].GetRange(0, minionsSelected[typeList.Key]);   
                }
            }
        }

        public void RemoveMinionInArea(GameObject minion)
        {
            var minionsType = minion.GetComponent<Minion>().typeMinion;
        
            if (_minionsListType[minionsType].Contains(minion))
            {
                if (minion.GetComponent<Minion>().follow)
                {
                    _minionsListTypeFollowing[minionsType].Remove(minion);
                }
                _minionsListType[minionsType].Remove(minion);
            }
        }
    
        public void AddMinionInArea(GameObject minion)
        {
            var minionsType = minion.GetComponent<Minion>().typeMinion;
        
            if (!_minionsListType[minionsType].Contains(minion))
            {
                _minionsListType[minionsType].Add(minion);
            }
        }
    
        public void UpdateFieldText()
        {
            fireMinionsTargeted.text = _minionsListTypeFollowing["fire"].Count.ToString();
            airMinionsTargeted.text = _minionsListTypeFollowing["air"].Count.ToString();
            waterMinionsTargeted.text = _minionsListTypeFollowing["water"].Count.ToString();
            earthMinionsTargeted.text = _minionsListTypeFollowing["earth"].Count.ToString();
        }

        public Dictionary<string, List<GameObject>> GetMinionsListBufferForFlag()
        {
            return _minionsListBufferForFlag;
        }

        public void ClearMinionForFlagBuffer(GameObject flag)
        {
            foreach (var minionList in _minionsListTypeFollowing)
            {
                foreach (var minion in minionList.Value.ToList())
                {
                    if (_minionsListBufferForFlag[minionList.Key].Contains(minion))
                    {
                        minion.GetComponent<Minion>().objectToFollow = flag.transform;
                        _minionsListTypeFollowing[minionList.Key].Remove(minion);
                        _minionsListBufferForFlag[minionList.Key].Remove(minion);
                    }
                }
            }
            _minionsListBufferForFlag.Clear();
        }
        private void InitMinionsListBuffer()
        {
            _minionsListBufferForFlag.Add("air", new List<GameObject>());
            _minionsListBufferForFlag.Add("fire", new List<GameObject>());
            _minionsListBufferForFlag.Add("water", new List<GameObject>());
            _minionsListBufferForFlag.Add("earth", new List<GameObject>());
        }
    }
}