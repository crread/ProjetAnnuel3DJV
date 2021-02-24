using System.Collections.Generic;
using Game.Minions;
using UnityEngine;

namespace Game.Flag
{
    public class Flag : MonoBehaviour
    {
        public GameObject flagGameObject;
        private Dictionary<string, List<GameObject>> _minionsOnFlag = new Dictionary<string, List<GameObject>>();
        private int _minionsCounter = 0;
        public Game gameScript;

        private void Update()
        {
            if (_minionsCounter <= 0)
            {
                DestroyThis();
            }
        }

        private void Start()
        {
            gameScript = GameObject.Find("Scripts").GetComponent<Game>();
        }
    
        private void DestroyThis()
        {
            Destroy(flagGameObject, 0.0f);
            gameScript.GetFlagList().Remove(this);
            Destroy(this);
        }

        public void SetMinionsOnFlag(Dictionary<string, List<GameObject>> minions)
        {
            _minionsOnFlag = new Dictionary<string, List<GameObject>>(minions);
            
            foreach (var minionList in _minionsOnFlag)
            {
                _minionsCounter += _minionsOnFlag[minionList.Key].Count;
            }
        }

        public void RemoveMinion(GameObject minion)
        {
            var typeMinion = minion.GetComponent<Minion>().typeMinion;
            if (_minionsOnFlag.ContainsKey(typeMinion) && _minionsOnFlag[typeMinion].Contains(minion))
            {
                _minionsOnFlag[minion.GetComponent<Minion>().typeMinion].Remove(minion);
                _minionsCounter -= 1;
            }
        }
    }
}
