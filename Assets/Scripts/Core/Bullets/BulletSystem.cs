using System.Collections.Generic;
using Core.Level;
using Core.Pool;
using UnityEngine;

namespace Core.Bullets
{
    public sealed class BulletSystem : Pool<Bullet>, IGameFixedUpdateListener
    {
        [SerializeField] private LevelBounds _levelBounds;

        private readonly List<Bullet> _cacheBullets = new();

        private MonoPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = new MonoPool<Bullet>(Prefab, Size, Container);
        }


        public void OnFixedUpdate(float deltaTime)
        {
            _cacheBullets.Clear();
            _cacheBullets.AddRange(ActiveObject);

            for (int i = 0, count = _cacheBullets.Count; i < count; i++)
            {
                var bullet = _cacheBullets[i];

                if (!_levelBounds.IsBounds(bullet.transform.position))
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

        public void Fire(Args args)
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