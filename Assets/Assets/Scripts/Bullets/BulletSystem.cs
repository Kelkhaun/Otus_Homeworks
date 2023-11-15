using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : Pool<Bullet>
    {
        [SerializeField] private LevelBounds _levelBounds;

        private readonly List<Bullet> _cacheBullets = new();

        private MonoPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = new MonoPool<Bullet>(Prefab, Size, Container, true);
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
            bullet.CollisionEntered -= OnBulletCollision;
            bullet.transform.SetParent(Container);
            ActiveObject.Remove(bullet);
        }

        public void FlyBulletByArgs(Args args)
        {
            Bullet bullet = _bulletPool.Get();
            bullet.transform.SetParent(WorldTransform);
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.Damage = args.damage;
            bullet.IsPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            ActiveObject.Add(bullet);
            bullet.CollisionEntered += OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            Release(bullet);
        }

        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}