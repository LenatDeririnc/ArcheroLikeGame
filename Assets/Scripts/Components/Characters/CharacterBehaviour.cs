using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ScriptableObjects.Characters;
using UnityEngine.AI;

namespace Components.Characters
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [HideInInspector] public CharacterProperties characterProperties;

        public State currentState;

        public List<Transform> pointsOfInterests = new List<Transform>();

        private void Awake()
        {
            characterProperties = GetComponent<CharacterProperties>();
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
            if (state == null || state == currentState)
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