using System;
using Extensions;
using UnityEngine;

namespace Components.Characters.Triggers
{
    public class ShootingRange : MonoBehaviour
    {
        public bool isShooting;

        [SerializeField] private LayerMask selectingMask;
        
        public Action<Collider> StartShootingAction;
        public Action<Collider> StopShootingAction;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!selectingMask.IsInLayerMask(other.gameObject.layer))
                return;
            
            StartShootingAction?.Invoke(other);
            isShooting = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!selectingMask.IsInLayerMask(other.gameObject.layer))
                return;
            
            StopShootingAction?.Invoke(other);
            isShooting = false;
        }
    }
}