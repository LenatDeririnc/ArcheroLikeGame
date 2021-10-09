using System;
using System.Collections;
using UnityEngine;

namespace Tools.Timer
{
    public class Timer
    {
        public Action End;
        public bool IsActive { get; private set; }

        private readonly MonoBehaviour m_context;
        private Coroutine m_coroutine;

        public Timer(MonoBehaviour context)
        {
            m_context = context;
            End += SetIsActiveFalse;
        }
        
        private void SetIsActiveFalse()
        {
            IsActive = false;
        }

        public void Start(IEnumerator action)
        {
            IsActive = true;
            m_coroutine = m_context.StartCoroutine(action);
        }

        public void Stop()
        {
            if (!IsActive)
                return;
            
            m_context.StopCoroutine(m_coroutine);
            IsActive = false;
        }
    }
}