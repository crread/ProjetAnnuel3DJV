using UnityEngine;

namespace Game
{
    public class EndZoneScript : MonoBehaviour
    {
        private Game _gameManager;
        private void Start()
        {
            _gameManager = GameObject.Find("Scripts").GetComponent<Game>();
        }

        private void OnTriggerEnter(Collider player)
        {
            if (player.gameObject.CompareTag("Player"))
            {
                _gameManager.EndGame(true);
            }
        }
    }
}
