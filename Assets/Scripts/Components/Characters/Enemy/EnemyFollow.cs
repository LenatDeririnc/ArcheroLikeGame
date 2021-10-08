using System;
using UnityEngine;
using UnityEngine.AI;

namespace Components.Characters.Enemy
{
    public class EnemyFollow : MonoBehaviour
    {
        private NavMeshAgent m_agent;
        private Transform m_transform;

        [SerializeField] private Transform m_followPoint;

        public void SetFollowPoint(Transform point)
        {
            m_followPoint = point;
        }

        private void Awake()
        {
            m_transform = transform;
            m_agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (m_agent == null)
                throw new Exception("NavMeshAgent not found");

            if (m_followPoint == null)
                return;

            Vector3 newPosition = new Vector3(m_followPoint.position.x, m_transform.position.y, m_followPoint.position.z);

            m_agent.SetDestination(newPosition);
        }
    }
}