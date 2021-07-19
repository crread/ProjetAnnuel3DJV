using UnityEngine;
using UnityEngine.Events;

public class DoorOpenedDispatcher : MonoBehaviour
{
    public UnityEvent doorOpened;
    public void OpenDoor()
    {
        doorOpened.Invoke();
    }
}
