using UnityEngine;

namespace ShootEmUp
{
    internal static class BulletUtils
    {
        internal static bool TryDealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return true;
            }

            if (bullet._isPlayer == team.IsPlayer)
            {
                return false;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet._damage);
                return true; 
            }

            return false; 
        }
    }
}