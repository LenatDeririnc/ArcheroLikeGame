using System;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.Characters.Enemy;
using ScriptableObjects.Characters.Enemy.MovementStates;
using ScriptableObjects.Weapons;
using UnityEngine.AI;

namespace Components.Characters.Enemy
{
    public class EnemyMovementStateMachine : MonoBehaviour
    {
        private MovementState m_currentMoveState;
        public MovementState CurrentMoveState => m_currentMoveState;

        private CharacterProperties m_properties;
        public NavMeshAgent Agent => m_agent;
        public Transform Transform => m_transform;

        public Transform walkPoint;

        [SerializeField] private MovementState startMoveState;

        private NavMeshAgent m_agent;
        private Transform m_transform;

        private void Awake()
        {
            m_transform = transform;
            m_agent = GetComponent<NavMeshAgent>();
            m_properties = GetComponent<CharacterProperties>();

            SetMoveState(startMoveState);
            
            m_properties.onGetDamage += arg0 =>
            {
                walkPoint = arg0.transform;
                SetMoveState(ScriptableObject.CreateInstance<FollowState>());
            };
        }

        public void SetMoveState(MovementState movementState)
        {
            if (movementState == null)
                return;

            movementState = Instantiate(movementState);
            movementState.enemyMovementStateMachine = this;
            movementState.Init();

            m_currentMoveState = movementState;
        }

        public void ClearMoveState()
        {
            m_currentMoveState = null;
        }

        private void Update()
        {
            if (m_currentMoveState == null)
                return;

            m_currentMoveState.Update();
        }
    }
}