using System.Collections.Generic;
using Game.Minions;
using UnityEngine;

namespace Game.Flag
{
    public class Flag : MonoBehaviour
    {
        public GameObject flagGameObject;
        
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
            // gameScript.GetFlagList().Remove(this);
            Destroy(this);
        }
    }
}
