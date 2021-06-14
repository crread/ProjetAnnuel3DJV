using System;
using UnityEngine;
using UnityEngine.AI;


namespace Script.Modules
{
    public class SpeedModule : TModule
    {
        [SerializeField] private float speed;
        [SerializeField] private NavMeshAgent  nav ;

        private void Awake()
        {
            TAccessor<SpeedModule>.Instance().Add(this);
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        public NavMeshAgent Nav
        {
            get => nav;
            set => nav = value;
        }
    }
}
