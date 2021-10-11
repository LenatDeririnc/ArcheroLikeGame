using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ScriptableObjects.Characters;
using ScriptableObjects.Characters.States;
using UnityEngine.AI;

namespace Components.Characters
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [HideInInspector] public CharacterProperties characterProperties;
        public State currentState;
        public List<Transform> pointsOfInterests = new List<Transform>();
        
        public static State inputState;
        public static State attackState;
        public static State followState;
        

        private void Awake()
        {
            characterProperties = GetComponent<CharacterProperties>();
            CharacterProperties.ONCharacterPropertiesInit += () => characterProperties = GetComponent<CharacterProperties>();

            inputState ??= ScriptableObject.CreateInstance<InputMoveState>();
            attackState ??= ScriptableObject.CreateInstance<AttackState>();
            followState ??= ScriptableObject.CreateInstance<FollowTargetState>();
        }

        private void Start()
        {
            InitState(currentState);
        }
        
        public void AddInterestPoint(Transform point)
        {
            if (pointsOfInterests.Contains(point))
                return;
            
            if (point == characterProperties.Transform)
                return;

            pointsOfInterests.Add(point);
        }

        public void RemoveInterestPoint(Transform point)
        {
            if (!pointsOfInterests.Contains(point))
                return;

            pointsOfInterests.Remove(point);
        }

        public void InitState(State state)
        {
            if (state == null)
                return;
            
            state = Instantiate(state);
            state.Init(this);
            currentState = state;
        }

        public void SetState(State state)
        {
            if (State.IsStatesEqual(currentState, state))
                return;

            InitState(state);
        }

        public void Update()
        {
            if (currentState == null)
                return;
            
            currentState.Update();
        }
    }
}