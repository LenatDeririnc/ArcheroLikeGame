using System;
using Components.Characters;
using Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjects.Characters.States
{
    [CreateAssetMenu(fileName = "FollowTargetState", menuName = "CharacterStates/FollowTargetState", order = 1)]
    public class FollowTargetState : State
    {
        public override string StateName() => "FollowTargetState";
        
        private CharacterProperties m_properties;
        private NavMeshAgent m_agent;
        private Transform m_transform;

        public override void Init(CharacterBehaviour context)
        {
            base.Init(context);
            m_properties = characterBehaviour.characterProperties;
            m_agent = m_properties.NavMeshAgent;
            m_transform = m_properties.Transform;
        }

        public override void Update()
        {
            if (characterBehaviour == null)
                throw new Exception("characterBehaviour not found");
            
            if (m_agent == null)
                throw new Exception("NavMeshAgent not found");

            var pointsOfInterests = characterBehaviour.pointsOfInterests;
            var characterTransform = m_properties.Transform;

            var followPoint = TransformHelper.FindNear(characterTransform, pointsOfInterests);
            
            if (followPoint == null)
                return;

            var followPointPosition = followPoint.position;
            Vector3 newPosition = new Vector3(followPointPosition.x, m_transform.position.y, followPointPosition.z);

            m_agent.SetDestination(newPosition);
            m_agent.stoppingDistance = 0;
        }
    }
}