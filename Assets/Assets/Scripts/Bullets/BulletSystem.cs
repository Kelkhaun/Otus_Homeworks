using System.Collections.Generic;
using Assets.Scripts.Components;
using Assets.Scripts.Level;
using Assets.Scripts.Pool;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public sealed class BulletSystem : Pool<Bullet>
    {
        [SerializeField] private LevelBounds _levelBounds;

        private readonly List<Bullet> _cacheBullets = new();

        private MonoPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = new MonoPool<Bullet>(Prefab, Size, Container);
        }

        private void FixedUpdate()
        {
            _cacheBullets.Clear();
            _cacheBullets.AddRange(ActiveObject);

            for (int i = 0, count = _cacheBullets.Count; i < count; i++)
            {
                var bullet = _cacheBullets[i];

                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    Release(bullet);
                }
            }
        }

        public override Bullet Get()
        {
            return _bulletPool.Get();
        }

        public override void Release(Bullet bullet)
        {
            bullet.OnCollisionEntered -= OnCollisionEntered;
            bullet.transform.SetParent(Container);
            ActiveObject.Remove(bullet);
        }

        public void FlyBulletByArgs(Args args)
        {
            Bullet bullet = _bulletPool.Get();
            bullet.transform.SetParent(WorldTransform);
            bullet.SetPosition(args.Position);
            bullet.SetColor(args.Color);
            bullet.SetPhysicsLayer(args.PhysicsLayer);
            bullet.SetDamage(args.Damage);
            bullet.SetIsPlayer(args.IsPlayer);
            bullet.SetVelocity(args.Velocity);

            ActiveObject.Add(bullet);
            bullet.OnCollisionEntered += OnCollisionEntered;
        }

        private void OnCollisionEntered(Bullet bullet, GameObject collisionObject)
        {
            Release(bullet);
            
            if (!collisionObject.TryGetComponent(out TeamComponent team))
            {
                return;
            }
            
            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (collisionObject.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
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