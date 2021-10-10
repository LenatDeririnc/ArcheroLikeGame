using System;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjects.Characters.Enemy.States
{
    [CreateAssetMenu(fileName = "FollowState", menuName = "EnemyStates/FollowState", order = 1)]
    public class FollowState : State
    {
        private NavMeshAgent m_agent;
        private Transform m_transform;

        public override void Init()
        {
            m_agent = EnemyStateMachine.Agent;
            m_transform = EnemyStateMachine.Transform;
        }

        public override void Update()
        {
            if (m_agent == null)
                throw new Exception("NavMeshAgent not found");

            var followPoint = EnemyStateMachine.walkPoint;
            
            if (followPoint == null)
                return;

            Vector3 newPosition = new Vector3(followPoint.position.x, m_transform.position.y, followPoint.position.z);

            m_agent.SetDestination(newPosition);
        }
    }
}