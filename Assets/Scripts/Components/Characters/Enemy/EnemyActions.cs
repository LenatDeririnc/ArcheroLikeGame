using System;
using Helpers;
using UnityEngine;
using Extensions;
using ScriptableObjects.Characters;
using UnityEngine.PlayerLoop;

namespace Components.Characters.Enemy
{
    public class EnemyActions : MonoBehaviour
    {
        private static readonly string PlayerLayer = "Player";
        
        private CharacterProperties m_properties;
        private CharacterBehaviour m_behaviour;

        private bool m_isAttackMode;
        
        private void Awake()
        {
            Init();
            CharacterProperties.ONCharacterPropertiesInit += Init;
        }

        private void Init()
        {
            m_properties = GetComponent<CharacterProperties>();
            m_behaviour = m_properties.CharacterBehaviour;
        }

        public void SetAttackMode(bool state) => m_isAttackMode = state;

        private void Update()
        {
            if (!m_isAttackMode)
                return;
            
            var characterTransform = m_properties.Transform;
            var nearPoint = TransformHelper.FindNear(characterTransform, m_behaviour.pointsOfInterests);
            
            if (nearPoint == null)
                return;
            
            RaycastHit hit;

            var direction = nearPoint.position - characterTransform.position;
            Ray ray = new Ray(characterTransform.position, direction);
            Debug.DrawLine(characterTransform.position, nearPoint.position, Color.red);
            if (!Physics.Raycast(ray, out hit))
                return;

            if (hit.transform.gameObject.layer != LayerMask.NameToLayer(PlayerLayer))
            {
                m_behaviour.SetState(CharacterBehaviour.followState);
                return;
            }

            m_behaviour.SetState(CharacterBehaviour.attackState);
        }
    }
}