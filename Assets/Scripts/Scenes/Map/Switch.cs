using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Map
{
    public class Switch : MonoBehaviour
    {
        public GameObject parent;
        public List<GameObject> triggeredElement;
        public int numberToTrigger;
        private int _minionsOnArea;

        public void AddMinionInArea()
        {
            _minionsOnArea += 1;
            ControlMinionsInArea();
        }
        
        public void RemoveMinionInArea()
        {
            _minionsOnArea -= 1;
            ControlMinionsInArea();
        }

        private void ControlMinionsInArea()
        {
            if (_minionsOnArea >= numberToTrigger)
            {
                Debug.Log("Enough minions");
            }
        }
    }
}
