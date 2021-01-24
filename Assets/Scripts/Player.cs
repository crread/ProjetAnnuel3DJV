using System;
using System.Collections.Generic;
using MinionScripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public NavMeshAgent targetAgent;
    public Collider groundCollider;
    public Camera raycastCamera;
    public Text fireMinionsTargeted;
    public Text airMinionsTargeted;
    public Text earthMinionsTargeted;
    public Text waterMinionsTargeted;

    private readonly Dictionary<string, List<GameObject>> _minionsListType = new Dictionary<string, List<GameObject>>();
    private readonly Dictionary<string, List<GameObject>> _minionsListTypeFollowing = new Dictionary<string, List<GameObject>>();
    private List<GameObject> bufferMinionToMove = new List<GameObject>();
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
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_disableMove )
        {
            var ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

            if (groundCollider.Raycast(ray, out var hit, float.MaxValue))
            {
                targetAgent.SetDestination(hit.point);
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
                    minion.GetComponent<Minion>().SwitchFollowPlayerToTrue();
                    _minionsListTypeFollowing[minionList.Key].Add(minion);   
                }
            }
        }
        UpdateFieldText();
    }

    public void LoadMinionBuffer(int nbMinionsWater, int nbMinionsAir, int nbMinionsEarth, int nbMinionsFire)
    {
        /*
        bufferMinionToMove += _minionsListTypeFollowing["water"].GetRange(0, nbMinionsWater);
        bufferMinionToMove += _minionsListTypeFollowing["air"].GetRange(0, nbMinionsAir);
        bufferMinionToMove += _minionsListTypeFollowing["earth"].GetRange(0, nbMinionsEarth);
        bufferMinionToMove += _minionsListTypeFollowing["fire"].GetRange(0, nbMinionsFire);
        */
    }
    
    public void RemoveMinionInArea(GameObject minion)
    {
        var minionsType = minion.GetComponent<Minion>().GetTypeMinion();
        
        if (_minionsListType[minionsType].Contains(minion))
        {
            if (minion.GetComponent<Minion>().followPlayer)
            {
                minion.GetComponent<Minion>().SwitchFollowPlayerToFalse();
                _minionsListTypeFollowing[minionsType].Remove(minion);
            }
            _minionsListType[minionsType].Remove(minion);
        }
        UpdateFieldText();
    }
    
    public void AddMinionInArea(GameObject minion)
    {
        var minionsType = minion.GetComponent<Minion>().GetTypeMinion();
        
        if (!_minionsListType[minionsType].Contains(minion))
        {
            _minionsListType[minionsType].Add(minion);
        }
    }

    private void UpdateFieldText()
    {
        fireMinionsTargeted.text = _minionsListTypeFollowing["fire"].Count.ToString();
        airMinionsTargeted.text = _minionsListTypeFollowing["air"].Count.ToString();
        waterMinionsTargeted.text = _minionsListTypeFollowing["water"].Count.ToString();
        earthMinionsTargeted.text = _minionsListTypeFollowing["earth"].Count.ToString();
    }
}