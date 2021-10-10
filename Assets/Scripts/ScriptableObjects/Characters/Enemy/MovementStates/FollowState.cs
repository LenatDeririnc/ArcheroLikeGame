using System;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjects.Characters.Enemy.MovementStates
{
    [CreateAssetMenu(fileName = "FollowState", menuName = "EnemyStates/FollowState", order = 1)]
    public class FollowState : MovementState
    {
        private NavMeshAgent m_agent;
        private Transform m_transform;

        public override void Init()
        {
            m_agent = enemyMovementStateMachine.Agent;
            m_transform = enemyMovementStateMachine.Transform;
        }

        public override void Update()
        {
            if (m_agent == null)
                throw new Exception("NavMeshAgent not found");

            var followPoint = enemyMovementStateMachine.walkPoint;
            
            if (followPoint == null)
                return;

            Vector3 newPosition = new Vector3(followPoint.position.x, m_transform.position.y, followPoint.position.z);

            m_agent.SetDestination(newPosition);
        }
    }
}