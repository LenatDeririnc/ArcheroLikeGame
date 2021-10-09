using ScriptableObjects.Weapons;
using UnityEngine;

namespace Components.Weapons.Bullets
{
    public abstract class BulletMovement : MonoBehaviour
    {
        [SerializeField] protected Weapon m_weaponProperties;
        protected Transform m_transform;

        protected virtual void Awake()
        {
            m_transform = transform;
        }

        public abstract void Move();
    }
}