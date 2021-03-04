using System.Collections.Generic;
using Map.Minions;
using UnityEngine;

namespace Game.Switch
{
    public class Switch : MonoBehaviour
    {
        public List<GameObject> triggeredElement;
        public int numberToTrigger;
        public GameObject player;
        public string typeMinion;
        public bool enoughMinion = false;    
        
        private int _minionsOnArea;
        private GameObject _counterTextGameObject;
        private TextMesh _counterTextMesh;
        
        private void Start()
        {
            _counterTextGameObject = new GameObject();
            _counterTextMesh = _counterTextGameObject.AddComponent<TextMesh>();
            _counterTextGameObject.AddComponent<MeshRenderer>();
            _counterTextMesh.text = $"{_minionsOnArea}/{numberToTrigger}";
            _counterTextMesh.color = Color.red;
            _counterTextMesh.anchor = TextAnchor.MiddleCenter;
            _counterTextMesh.fontSize = 26;
            var switchPosition = this.GetComponent<Transform>().position;
            _counterTextGameObject.transform.position = new Vector3(switchPosition.x, switchPosition.y + 5, switchPosition.z);
            _counterTextGameObject.transform.LookAt(player.transform.position);
        }

        private void Update()
        {
            _counterTextMesh.text = $"{_minionsOnArea}/{numberToTrigger}";
        }

        private void FixedUpdate()
        {
            _counterTextGameObject.transform.LookAt(player.transform.position);
        }

        public void AddMinionInArea(GameObject minion)
        {
            if (typeMinion == "" || minion.GetComponent<Minion>().typeMinion == typeMinion)
            {
                _minionsOnArea += 1;
                ControlMinionsInArea();
            }
        }
        
        public void RemoveMinionInArea(GameObject minion)
        {
            if (typeMinion == "" || minion.GetComponent<Minion>().typeMinion == typeMinion)
            {
                _minionsOnArea -= 1;
                ControlMinionsInArea();
            }
        }

        private void ControlMinionsInArea() => enoughMinion = _minionsOnArea >= numberToTrigger;
    }
}
