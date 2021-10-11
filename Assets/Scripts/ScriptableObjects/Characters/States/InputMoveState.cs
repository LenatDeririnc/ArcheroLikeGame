using Components.Characters;
using Components.Characters.Player;
using UnityEngine;

namespace ScriptableObjects.Characters.States
{
    [CreateAssetMenu(fileName = "InputMoveState", menuName = "CharacterStates/InputMoveState", order = 1)]
    public class InputMoveState : State
    {
        private CharacterProperties m_properties;
        private CharacterController m_controller;

        public override void Init(CharacterBehaviour context)
        {
            base.Init(context);
            m_properties = characterBehaviour.characterProperties;
            m_controller = m_properties.CharacterController;
        }

        public override void Update()
        {
            var input = PlayerMovement.input;
            m_controller.Move(input * m_properties.movementSpeed * Time.deltaTime);
        }
    }
}