using UnityEngine;

namespace Components.Triggers
{
    public abstract class AbstractTrigger : MonoBehaviour
    {
        [SerializeField] protected bool m_hideRenderMash = true;
        [SerializeField] protected LayerMask m_objectMask = 0;

        protected abstract void OnTriggerEnter(Collider other);

        protected abstract void OnTriggerExit(Collider other);

        protected abstract void OnTriggerStay(Collider other);

        protected void Awake()
        {
            HideRenderMesh();
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