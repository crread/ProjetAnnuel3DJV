using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class EndZoneScript : MonoBehaviour
    {
        private BoxCollider _endZoneCollision;
        void Start()
        {
            _endZoneCollision = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider player)
        {
            if (player.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
}
