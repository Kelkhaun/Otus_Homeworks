using System;
using Core.Bullets;
using Core.Components;
using Infrastructure.DI;
using UnityEngine;

namespace Core.Character
{
    [Serializable]
    public sealed class PlayerShooter
    {
        private WeaponComponent _characterWeapon;
        private BulletConfig _bulletConfig;
        private BulletSystem _bulletSystem;

        [Inject]
        public void Construct(BulletSystem bulletSystem, PlayerService playerService)
        {
            _bulletSystem = bulletSystem;
            _characterWeapon =  playerService.Player.GetComponent<WeaponComponent>();
            _bulletConfig = playerService.BulletConfig;
        }
        
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