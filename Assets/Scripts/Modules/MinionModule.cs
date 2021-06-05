using System;
using UnityEngine;
namespace Script.Modules
{
    public class MinionModule : TModule
    {
        
        [SerializeField] private bool follow;
        [SerializeField] private Transform minion;
        [SerializeField] private Transform objectToFollow;
        [SerializeField] private string typeMinion;
        [SerializeField] private Rigidbody rb;
        private void Awake()
        {
            TAccessor<MinionModule>.Instance().Add(this);
        }
        
        public bool Follow 
        {
            get => follow;
            set => follow = value;
        }

        public Transform Minion
        {
            get => minion;
            set => minion = value;
        }
        
        public Transform ObjectToFollow
        {
            get => objectToFollow;
            set => objectToFollow = value;
        }
        
        public string TypeMinion
        {
            get => typeMinion;
            set => typeMinion = value;
        }
        
        public Rigidbody Rb
        {
            get => rb;
            set => rb = value;
        }

    }
}