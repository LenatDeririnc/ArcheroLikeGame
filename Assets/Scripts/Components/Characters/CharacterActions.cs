using System;
using Components.Characters.Enemy;
using Components.HUD;
using ScriptableObjects.Characters;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Characters
{
    public class CharacterActions : MonoBehaviour
    {
        public static UnityAction<Transform> ONCharacterDie;
        public UnityAction<Transform> ONGetDamage;

        [SerializeField] private GameObject m_droppingMoney;
        
        private CharacterProperties m_properties;
        private HUDController m_hudController;

        private void Awake()
        {
            m_properties = GetComponent<CharacterProperties>();
            CharacterProperties.ONCharacterPropertiesInit += () => m_properties = GetComponent<CharacterProperties>();
            
            ONCharacterDie += OnCharDie;
            ONGetDamage += OnCharDamaged;
            
            m_hudController = HUDController.self;
            HUDController.ONHUDControllerInit += () => m_hudController = HUDController.self;
        }

        private void Start()
        {
            if (m_properties.isPlayer)
                m_hudController.SetHp((int) m_properties.health);
        }

        private void OnCharDamaged(Transform transform)
        {
            if (m_properties.isPlayer)
            {
                m_hudController.SetHp((int) m_properties.health);
                return;
            }

            EnemyActions enemyActions = GetComponent<EnemyActions>();
            if (enemyActions == null)
                return;
            
            var CharBehaviour = m_properties.CharacterBehaviour;
            CharBehaviour.AddInterestPoint(transform);
            enemyActions.SetAttackMode(true);
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
                
                if (m_properties.isPlayer)
                    return;
                
                var droppedMoney = Instantiate(m_droppingMoney);
                droppedMoney.transform.position = m_properties.Transform.position;
                return;
            }

            if (sender == null)
                return;
            
            ONGetDamage?.Invoke(sender.Transform);
        }
    }
}