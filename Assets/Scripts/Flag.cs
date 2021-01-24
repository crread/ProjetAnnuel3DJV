using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    private Dictionary<string, List<GameObject>> _minionsOnFlag = new Dictionary<string, List<GameObject>>();

    public void SetMinionsOnFlag(Dictionary<string, List<GameObject>> minions)
    {
        _minionsOnFlag = minions;
    }
}
