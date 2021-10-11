using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Triggers
{
    public class TriggerTransform : AbstractTrigger
    {
        public UnityEvent<Transform> OnEnter;
        public UnityEvent<Transform> OnStay;
        public UnityEvent<Transform> OnExit;

        private void TriggerAction(Collider other, UnityEvent<Transform> @event)
        {
            if (@event == null)
                return;

            var otherTransform = other.transform;
            
            if (m_objectMask.IsInLayerMask(other.gameObject.layer))
                @event?.Invoke(otherTransform);
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