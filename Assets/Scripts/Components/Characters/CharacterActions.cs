﻿using System;
using ScriptableObjects.Characters;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Characters
{
    public class CharacterActions : MonoBehaviour
    {
        public static UnityAction<Transform> ONCharacterDie;
        public UnityAction<Transform> ONGetDamage;
        
        private CharacterProperties m_properties;

        private void Awake()
        {
            CharacterProperties.ONCharacterPropertiesInit += () =>
            {
                m_properties = GetComponent<CharacterProperties>();
                ONCharacterDie += OnCharDie;
                ONGetDamage += OnCharDamaged;
            };
        }

        private void OnCharDamaged(Transform transform)
        {
            if (m_properties.isPlayer)
                return;
            
            var CharBehaviour = m_properties.CharacterBehaviour;
            CharBehaviour.AddInterestPoint(transform);
            CharBehaviour.SetState(CharacterBehaviour.attackState);
        }

        private void OnCharDie(Transform transform)
        {
            var CharBehaviour = m_properties.CharacterBehaviour;
            CharBehaviour.RemoveInterestPoint(transform);
        }
        
        public void GetDamage(CharacterProperties sender, float damage)
        {
            m_properties.health -= damage;

            if (m_properties.health <= 0)
            {
                ONCharacterDie?.Invoke(m_properties.Transform);
                gameObject.SetActive(false);
                return;
            }

            if (sender == null)
                return;
            
            ONGetDamage?.Invoke(sender.Transform);
        }
    }
}