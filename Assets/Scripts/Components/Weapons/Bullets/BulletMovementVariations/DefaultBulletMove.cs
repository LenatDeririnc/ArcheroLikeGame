using UnityEngine;

namespace Components.Weapons.Bullets.BulletMovementVariations
{
    [AddComponentMenu("BulletMovementTypes/DefaultMove")]
    public class DefaultBulletMove : BulletMovement
    {
        public override void Move()
        {
            m_transform.position += m_transform.forward * m_weaponProperties.BulletSpeed * Time.deltaTime;
        }
    }
}