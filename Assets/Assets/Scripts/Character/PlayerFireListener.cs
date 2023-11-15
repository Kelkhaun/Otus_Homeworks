using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerFireListener : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _characterWeapon;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public void OnFire()
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) _bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = _characterWeapon.Position,
                velocity = _characterWeapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}