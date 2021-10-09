using System;
using UnityEngine;

namespace Components
{
    public class GarbageCollector : MonoBehaviour
    {
        public static GarbageCollector self;
        public static Action GarbageCollectorInited;
        
        private Transform m_transform;
        public Transform Transform => m_transform;
        
        private void Awake()
        {
            self = this;
            m_transform = transform;
            
            GarbageCollectorInited?.Invoke();
        }

        public void ClearAllChildComponents()
        {
            foreach (var child in m_transform)
            {
                Destroy((GameObject)child);
            }
        }
    }
}