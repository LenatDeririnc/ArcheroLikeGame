using UnityEngine;

namespace Components.Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController m_controller;
        
        [SerializeField] private string m_verticalAxis = "Vertical";
        [SerializeField] private string m_horizontalAxis = "Horizontal";

        [Space] [SerializeField] private float m_movementSpeed = 2f;

        private void Awake()
        {
            m_controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(m_horizontalAxis);
            float vertical = Input.GetAxis(m_verticalAxis);

            if (horizontal == 0 && vertical == 0)
                return;

            Vector3 resultMovement = Vector3.ClampMagnitude(new Vector3(horizontal, 0, vertical), 1) * m_movementSpeed;

            m_controller.Move(resultMovement * Time.deltaTime);
        }
    }
}
