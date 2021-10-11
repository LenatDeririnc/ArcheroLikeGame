using System;
using ScriptableObjects.Characters;
using ScriptableObjects.Characters.States;
using UnityEngine;

namespace Components.Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public static Vector3 input = new Vector3(0, 0, 0);
        
        private CharacterProperties m_properties;
        private CharacterBehaviour m_behaviour;

        [SerializeField] private string m_verticalAxis = "Vertical";
        [SerializeField] private string m_horizontalAxis = "Horizontal";

        private void Awake()
        {
            Init();
            CharacterProperties.ONCharacterPropertiesInit += Init;
        }

        private void Init()
        {
            m_properties = GetComponent<CharacterProperties>();
            m_behaviour = m_properties.CharacterBehaviour;
        }

        private void SetState(bool isStaying)
        {
            if (isStaying)
            {
                m_behaviour.SetState(CharacterBehaviour.attackState);
                return;
            }
            
            m_behaviour.SetState(CharacterBehaviour.inputState);
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(m_horizontalAxis);
            float vertical = Input.GetAxis(m_verticalAxis);

            input = Vector3.ClampMagnitude(new Vector3(horizontal, 0, vertical), 1);

            SetState(horizontal == 0 && vertical == 0);
        }
    }
}
