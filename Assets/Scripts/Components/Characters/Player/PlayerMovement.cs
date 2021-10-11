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

        private State m_inputState;
        private State m_attackState;

        private bool m_isStaying = false;

        [SerializeField] private string m_verticalAxis = "Vertical";
        [SerializeField] private string m_horizontalAxis = "Horizontal";

        private void Awake()
        {
            m_properties = GetComponent<CharacterProperties>();
            m_behaviour = GetComponent<CharacterBehaviour>();
            m_inputState = ScriptableObject.CreateInstance<InputMoveState>();
            m_attackState = ScriptableObject.CreateInstance<AttackState>();
        }

        private void SetState(bool isStaying)
        {
            switch (isStaying)
            {
                case true when !m_isStaying:
                {
                    m_behaviour.SetState(m_attackState);
                    break;
                }
                case false when m_isStaying:
                {
                    m_behaviour.SetState(m_inputState);
                    break;
                }
            }

            m_isStaying = isStaying;
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
