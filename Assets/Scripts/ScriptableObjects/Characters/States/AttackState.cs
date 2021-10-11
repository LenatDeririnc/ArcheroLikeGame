using System;
using System.Collections;
using Components;
using Components.Characters;
using Components.Weapons.Bullets;
using Helpers;
using ScriptableObjects.Weapons;
using Tools.Timer;
using UnityEngine;

namespace ScriptableObjects.Characters.States
{
    [CreateAssetMenu(fileName = "AttackState", menuName = "CharacterStates/AttackState", order = 1)]
    public class AttackState : State
    {
        private GarbageCollector m_garbageCollector;
        private CharacterProperties m_properties;

        private Timer m_shootDelay;
        
        private void InitGarbageCollector()
        {
            m_garbageCollector = GarbageCollector.self;
            GarbageCollector.GarbageCollectorInited += InitGarbageCollector;
        }

        public override void Init(CharacterBehaviour context)
        {
            base.Init(context);
            m_shootDelay = new Timer(context);
            m_properties = context.characterProperties;
            InitGarbageCollector();
        }
        
        public void CreateBullet(Weapon weapon)
        {
            var playerPosition = m_properties.Transform.position;
            var dirPosition = TransformHelper.FindNear(m_properties.Transform, characterBehaviour.pointsOfInterests).position - playerPosition;
            var dirRotation = Quaternion.LookRotation(dirPosition, Vector3.up);
                
            var bullet = Instantiate(weapon.Bullet, m_garbageCollector.Transform).transform;
            var bulletProperties = bullet.GetComponent<Bullet>();
            bulletProperties.senderCharacter = m_properties;
            bullet.position = playerPosition;
            bullet.rotation = dirRotation;
            m_shootDelay.Start(ShootDelay(weapon));
        }
        
        IEnumerator ShootDelay(Weapon weapon)
        {
            yield return new WaitForSeconds(weapon.ShootInterval);
            m_shootDelay.End();
        }

        public override void Update()
        {
            if (m_properties == null)
                throw new Exception("not setted CharacterProperties");
            
            if (m_garbageCollector == null)
                throw new Exception("not setted GarbageCollector");

            if (characterBehaviour.pointsOfInterests.Count <= 0)
                return;
            
            if (m_shootDelay.IsActive)
                return;
            
            var weapon = m_properties.currentWeapon;
            if (weapon == null)
            {
                Debug.LogWarning($"not setted Weapon for character \"{m_properties.Transform.name}\"");
                return;
            }

            CreateBullet(weapon);
        }
    }
}