using Components.Characters;
using ScriptableObjects.Weapons;
using UnityEngine;

namespace Components.Weapons.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Weapon m_weaponProperties;
        [SerializeField] private BulletMovement m_movement;

        public CharacterProperties senderCharacter;

        public void SendDamage(Collider other)
        {
            var charActions = other.GetComponent<CharacterActions>();
            if (charActions == null)
                return;
            
            charActions.GetDamage(senderCharacter, m_weaponProperties.Damage);
        }

        private void Update()
        {
            m_movement.Move();
        }
    }
}