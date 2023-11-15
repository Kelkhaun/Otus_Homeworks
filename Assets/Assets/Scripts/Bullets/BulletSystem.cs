using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 50;
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;

        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        private MonoPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = new MonoPool<Bullet>(_prefab, _initialCount, _container, true);
        }

        private void FixedUpdate()
        {
            m_cache.Clear();
            m_cache.AddRange(m_activeBullets);

            for (int i = 0, count = m_cache.Count; i < count; i++)
            {
                var bullet = m_cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            Bullet bullet = _bulletPool.Get();
            
            bullet.transform.SetParent(_worldTransform);
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet._damage = args.damage;
            bullet._isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            m_activeBullets.Add(bullet);
            bullet.CollisionEntered += OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bool isDealDamage = BulletUtils.TryDealDamage(bullet, collision.gameObject);

            if (isDealDamage)
                RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.CollisionEntered -= OnBulletCollision;
            bullet.transform.SetParent(_container);
            m_activeBullets.Remove(bullet);
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