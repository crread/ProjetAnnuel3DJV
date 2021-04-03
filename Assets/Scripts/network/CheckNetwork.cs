using UnityEngine;

namespace network
{
    public class CheckNetwork : MonoBehaviour
    {
        public bool isNetworkAvailable = false;
        private void Start()
        {
            //call every 5 secs CheckNetwork
            InvokeRepeating(nameof(CheckingNetwork), 5.0f, 5.0f); 
        }

        public void CheckingNetwork()
        {
            isNetworkAvailable = Application.internetReachability != NetworkReachability.NotReachable;
        }
        
    }
}
