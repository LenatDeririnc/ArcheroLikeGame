using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Triggers
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private bool m_hideRenderMash = true;
        [SerializeField] private LayerMask m_objectMask = 0;

        private void Awake()
        {
            HideRenderMesh();
        }

        public UnityEvent<Collider> OnEnter;
        public UnityEvent<Collider> OnStay;
        public UnityEvent<Collider> OnExit;

        private void TriggerAction(Collider other, UnityEvent<Collider> @event)
        {
            if (@event == null)
                return;
            
            if (m_objectMask.IsInLayerMask(other.gameObject.layer))
                @event.Invoke(other);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            TriggerAction(other, OnEnter);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerAction(other, OnExit);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerAction(other, OnStay);
        }

        private void HideRenderMesh()
        {
            if (!m_hideRenderMash)
                return;
            
            var mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;
        }
    }
}