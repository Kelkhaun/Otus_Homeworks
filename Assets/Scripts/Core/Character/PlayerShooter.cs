using System;
using Core.Bullets;
using Core.Components;
using UnityEngine;

namespace Core.Character
{
    [Serializable]
    public sealed class PlayerShooter
    {
        [SerializeField] private WeaponComponent _characterWeapon;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public void Fire()
        {
            _bulletSystem.Fire(new BulletSystem.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _characterWeapon.Position,
                Velocity = _characterWeapon.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }
    }
}