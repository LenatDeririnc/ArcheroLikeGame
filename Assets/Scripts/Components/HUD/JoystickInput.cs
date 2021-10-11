using System;
using Components.Characters;
using Components.Characters.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components.HUD
{
    public class JoystickInput : MonoBehaviour
    {
        [SerializeField] private Joystick Joystick;
        private PlayerPointer m_playerPointer;

        private CharacterProperties m_characterProperties;
        private PlayerMovement m_playerMovement;

        private void Awake()
        {
            m_playerPointer = PlayerPointer.self;
            PlayerPointer.ONPlayerPointerInit += () => m_playerPointer = PlayerPointer.self;
        }

        private void Start()
        {
            m_characterProperties = m_playerPointer.m_properties;
            m_playerMovement = m_characterProperties.GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            m_playerMovement.isKeyboard = false;
            
            PlayerMovement.input = new Vector3(Joystick.Direction.x, 0, Joystick.Direction.y);
            m_playerMovement.SetState(Joystick.Horizontal == 0 && Joystick.Vertical == 0);
        }
    }
}