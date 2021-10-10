using System;
using Components.Weapons;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Characters
{
    public class CharacterProperties : MonoBehaviour
    {
        public UnityAction<Collider> OnCharacterDie;
        
        [SerializeField] private float m_health;
        public float Health => m_health;

        public Weapon CurrentWeapon;

        private Transform m_transform;
        
        public Transform Transform => m_transform;

        public UnityAction<Collider> onGetDamage;

        public Collider Collider;

        private void Awake()
        {
            m_transform = transform;
            Collider = GetComponent<Collider>();
        }

        public void GetDamage(CharacterProperties sender, float damage)
        {
            m_health -= damage;

            if (m_health <= 0)
            {
                OnCharacterDie?.Invoke(Collider);
                gameObject.SetActive(false);
                return;
            }

            if (sender == null)
                return;
            
            onGetDamage?.Invoke(sender.Collider);
        }
    }
}