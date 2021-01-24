using UnityEngine;

public class Minion : MonoBehaviour
{
    public bool follow = false;
    public Transform minion;
    public Transform objectToFollow;
    public string typeMinion;

    private void FixedUpdate()
    {
        if (follow)
        {
            UpdatePosition(objectToFollow);
        }
    }

    public string GetTypeMinion()
    {
        return typeMinion;
    }
    
    public void SwitchFollowPlayerToTrue()
    {
        follow = true;
    }
    
    public void SwitchFollowPlayerToFalse()
    {
        follow = false;
    }
    private void UpdatePosition(Transform positionToMove)
    {
        if (Vector3.SqrMagnitude(minion.position - positionToMove.position) > 4f)
        {
            minion.position = Vector3.MoveTowards(minion.position, positionToMove.position, Time.deltaTime + 0.1f);   
        }
    }
}