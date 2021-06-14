using System;
using Script.Updaters;
using UnityEngine;

namespace Script.ECS
{
    public class UpdateManager : MonoBehaviour
    {
        private void Update()
        {
            MovementUpdaterPlayer.Instance().SystemUpdate();
            SpeedUpdaterPlayer.Instance().SystemUpdate();
        }
    }
        
}
