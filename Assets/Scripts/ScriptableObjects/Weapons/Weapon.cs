using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Components.Weapons.Bullets;
using UnityEngine;

namespace ScriptableObjects.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Properties", menuName = "Weapon Properties", order = 1)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private float m_damage = 0;
        [SerializeField] private float m_bulletSpeed = 1;
        [SerializeField] private float m_shootInterval = 0.5f;
        [SerializeField] private GameObject m_bulletGameObject;
        private Bullet m_bullet;

        public float Damage => m_damage;
        public float BulletSpeed => m_bulletSpeed;
        public float ShootInterval => m_shootInterval;

        public Bullet Bullet
        {
            get
            {
                if (m_bullet != null)
                    return m_bullet;

                m_bullet = m_bulletGameObject.GetComponent<Bullet>();
                return m_bullet;
            }
        }
    }
}