using UnityEngine;

namespace Components.Characters
{
    public class CharacterGravity : MonoBehaviour
    {
        private CharacterProperties m_properties;

        private void Awake()
        {
            m_properties = GetComponent<CharacterProperties>();
        }

        private void Update()
        {
            if (m_properties.CharacterController.isGrounded)
                return;

            m_properties.CharacterController.Move(Physics.gravity * Time.deltaTime);
        }
    }
}