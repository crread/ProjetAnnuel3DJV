using Game.Minions;
using UnityEngine;

namespace Game.Switch
{
    public class Switch : MonoBehaviour
    {
        public GameObject player;
        public int numberToTrigger;
        public string typeMinion;
        public bool enoughMinion;    
        
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
            
            enoughMinion = false;
        }

        private void Update()
        {
            _counterTextMesh.text = $"{_minionsOnArea}/{numberToTrigger}";
        }

        private void FixedUpdate()
        {
            _counterTextGameObject.transform.LookAt(player.transform.position);
        }

        /// <summary>
        ///   <para>Add minion in the switch area</para>
        /// </summary>
        /// <param name="minion"></param>
        public void AddMinionInArea(GameObject minion)
        {
            if (typeMinion == "" || minion.GetComponent<Minion>().typeMinion == typeMinion)
            {
                _minionsOnArea += 1;
                ControlMinionsInArea();
            }
        }
        
        /// <summary>
        ///   <para>Remove minion from the switch area</para>
        /// </summary>
        /// <param name="minion"></param>
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
