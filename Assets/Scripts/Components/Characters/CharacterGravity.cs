using UnityEngine;

namespace Components.Characters
{
    public class CharacterGravity : MonoBehaviour
    {
        private CharacterController m_controller;

        private void Awake()
        {
            m_controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (m_controller.isGrounded)
                return;

            m_controller.Move(Physics.gravity * Time.deltaTime);
        }
    }
}