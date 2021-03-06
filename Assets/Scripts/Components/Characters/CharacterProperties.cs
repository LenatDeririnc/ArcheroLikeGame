using ScriptableObjects.Characters;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Components.Characters
{
    public class CharacterProperties : MonoBehaviour
    {
        public static UnityAction ONCharacterPropertiesInit;
        
        public bool isPlayer = false;
        
        public float movementSpeed;

        public float health;

        public Weapon currentWeapon;

        private Transform m_transform;
        
        public Transform Transform => m_transform;

        private Collider m_collider;
        public Collider Collider => m_collider;

        private NavMeshAgent m_navMeshAgent;
        public NavMeshAgent NavMeshAgent => m_navMeshAgent;

        private CharacterController m_characterController; 
        public CharacterController CharacterController => m_characterController;

        private CharacterBehaviour m_characterBehaviour;
        public CharacterBehaviour CharacterBehaviour => m_characterBehaviour;

        public int moneyCost = 0;
        
        private void Awake()
        {
            m_transform = transform;
            m_collider = GetComponent<Collider>();
            m_navMeshAgent = GetComponent<NavMeshAgent>();
            m_characterController = GetComponent<CharacterController>();
            m_characterBehaviour = GetComponent<CharacterBehaviour>();
            ONCharacterPropertiesInit?.Invoke();
        }
    }
}