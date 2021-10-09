using System;
using System.Collections;
using System.Collections.Generic;
using Components.Characters.Triggers;
using Tools.Timer;
using UnityEngine;

namespace Components.Characters
{
    public class CharacterShootingController : MonoBehaviour
    {
        private GarbageCollector m_garbageCollector;
        private CharacterProperties m_properties;
        private ShootingRange m_range;

        private Timer m_shootTimer;

        [SerializeField] private List<Transform> m_shootingPoints;

        private void InitGarbageCollector()
        {
            m_garbageCollector = GarbageCollector.self;
            GarbageCollector.GarbageCollectorInited += InitGarbageCollector;
        }
        
        private void Awake()
        {
            m_shootTimer = new Timer(this);
            m_range = GetComponentInChildren<ShootingRange>();
            m_properties = GetComponent<CharacterProperties>();
            InitGarbageCollector();
        }

        private void Start()
        {
            m_range.StartShootingAction += SetShootingPoint;
            m_range.StopShootingAction += UnsetShootingPoint;
        }

        private void SetShootingPoint(Collider collider)
        {
            m_shootingPoints.Add(collider.transform);
            if (!m_shootTimer.IsActive)
                m_shootTimer.Start(ShootDelay());
        }

        private void UnsetShootingPoint(Collider collider)
        {
            m_shootingPoints.Remove(collider.transform);
        }

        private Transform FindNearEnemy()
        {
            var playerPosition = m_properties.Transform.position;
            float distance = -1f;
            Transform lastTarget = null;
            
            foreach (var point in m_shootingPoints)
            {
                var enemyPosition = point.position;
                var dirPosition = enemyPosition - playerPosition;

                if (distance < 0 || dirPosition.magnitude < distance)
                {
                    distance = dirPosition.magnitude;
                    lastTarget = point;
                }
            }

            return lastTarget;
        }

        IEnumerator ShootDelay()
        {
            if (m_properties == null)
                throw new Exception("not setted CharacterProperties");
            
            if (m_garbageCollector == null)
                throw new Exception("not setted GarbageCollector");
            
            while (m_shootingPoints.Count > 0)
            {
                var playerPosition = m_properties.Transform.position;
                var dirPosition = FindNearEnemy().position - playerPosition;
                var dirRotation = Quaternion.LookRotation(dirPosition, Vector3.up);
                
                var weapon = m_properties.CurrentWeapon;
                var bullet = Instantiate(weapon.Bullet, m_garbageCollector.Transform).transform;
                bullet.position = playerPosition;
                bullet.rotation = dirRotation;

                yield return new WaitForSeconds(weapon.ShootInterval);
            }
            yield return null;
            m_shootTimer.End();
        }
    }
}