using System;
using System.Collections.Generic;
using Core.Level;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Bullets
{
    [Serializable]
    public sealed class BulletSystem : IGameFixedUpdateListener
    {
        private readonly List<Bullet> _cacheBullets = new();

        private LevelBounds _levelBounds;
        private BulletPool _bulletPool;

        [Inject]
        public void Construct(LevelBounds levelBounds, BulletPool bulletPool)
        {
            _levelBounds = levelBounds;
            _bulletPool = bulletPool;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            _cacheBullets.Clear();
            _cacheBullets.AddRange(_bulletPool.GetActiveObjects());

            for (int i = 0, count = _cacheBullets.Count; i < count; i++)
            {
                var bullet = _cacheBullets[i];

                if (!_levelBounds.IsBounds(bullet.transform.position))
                {
                    _bulletPool.Release(bullet);
                    bullet.OnCollisionEntered -= OnCollisionEntered;
                }
            }
        }

        public void Fire(Args args)
        {
            Bullet bullet = _bulletPool.Get();
            bullet.SetPosition(args.Position);
            bullet.SetColor(args.Color);
            bullet.SetPhysicsLayer(args.PhysicsLayer);
            bullet.SetDamage(args.Damage);
            bullet.SetIsPlayer(args.IsPlayer);
            bullet.SetVelocity(args.Velocity);

            _bulletPool.AddActiveObject(bullet);
            bullet.OnCollisionEntered += OnCollisionEntered;
        }

        private void OnCollisionEntered(Bullet bullet, GameObject collisionObject)
        {
            _bulletPool.Release(bullet);
            bullet.TryTakeDamage(collisionObject);
        }

        public struct Args
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public Color Color;
            public int PhysicsLayer;
            public int Damage;
            public bool IsPlayer;
        }
    }
}