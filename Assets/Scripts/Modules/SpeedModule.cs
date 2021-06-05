using System;
using UnityEngine;


namespace Script.Modules
{
    public class SpeedModule : TModule
    {
        [SerializeField] private float speed;

        private void Awake()
        {
            TAccessor<SpeedModule>.Instance().Add(this);
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
    }
}
