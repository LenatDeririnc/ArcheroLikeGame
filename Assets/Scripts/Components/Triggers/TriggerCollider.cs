using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Triggers
{
    public class TriggerCollider : AbstractTrigger
    {
        public UnityEvent<Collider> OnEnter;
        public UnityEvent<Collider> OnStay;
        public UnityEvent<Collider> OnExit;

        private void TriggerAction(Collider other, UnityEvent<Collider> @event)
        {
            if (@event == null)
                return;
            
            if (m_objectMask.IsInLayerMask(other.gameObject.layer))
                @event?.Invoke(other);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            TriggerAction(other, OnEnter);
        }

        protected override void OnTriggerExit(Collider other)
        {
            TriggerAction(other, OnExit);
        }

        protected override void OnTriggerStay(Collider other)
        {
            TriggerAction(other, OnStay);
        }
    }
}