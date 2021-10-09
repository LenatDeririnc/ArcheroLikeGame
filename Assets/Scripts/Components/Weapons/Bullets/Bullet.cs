using ScriptableObjects.Weapons;
using UnityEngine;

namespace Components.Weapons.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Weapon m_weaponProperties;
        [SerializeField] private BulletMovement m_movement;

        private Transform m_transform;

        public void SendDamage(Collider other)
        {
            
        }

        private void Awake()
        {
            m_transform = transform;
        }

        private void Update()
        {
            m_movement.Move();
        }
    }
}