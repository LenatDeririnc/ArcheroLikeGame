using System;
using Components.Weapons;
using ScriptableObjects.Weapons;
using UnityEngine;

namespace Components.Characters
{
    public class CharacterProperties : MonoBehaviour
    {
        [SerializeField] private float m_health;
        public float Health => m_health;

        public Weapon CurrentWeapon;

        private Transform m_transform;
        
        public Transform Transform => m_transform;

        private void Awake()
        {
            m_transform = transform;
        }
    }
}