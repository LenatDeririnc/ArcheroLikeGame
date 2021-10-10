using System;
using UnityEngine;
using ScriptableObjects.Characters.Enemy;
using ScriptableObjects.Characters.Enemy.States;
using UnityEngine.AI;

namespace Components.Characters.Enemy
{
    public class EnemyStateMachine : MonoBehaviour
    {
        public NavMeshAgent Agent => m_agent;
        public Transform Transform => m_transform;
        
        public State currentState;

        public Transform walkPoint;

        private NavMeshAgent m_agent;
        private Transform m_transform;

        private void Awake()
        {
            m_transform = transform;
            m_agent = GetComponent<NavMeshAgent>();
            SetState(currentState);
        }

        public void SetState(State state)
        {
            if (currentState == null)
                return;
            
            currentState = Instantiate(state);
            currentState.EnemyStateMachine = this;
            currentState.Init();
        }

        private void Update()
        {
            if (currentState == null)
                return;
            
            currentState.Update();
        }
    }
}