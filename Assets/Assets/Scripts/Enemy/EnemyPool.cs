using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : Pool<Enemy>
    {
        [Header("Spawn")] 
        [SerializeField] private EnemyPositions _enemyPositions;

        private MonoPool<Enemy> _bulletPool;

        public event Action<Enemy> EnemySpawned;

        private void Awake()
        {
            _bulletPool = new MonoPool<Enemy>(Prefab, Size, Container, true);
        }

        public bool AddActiveEnemy(Enemy enemy)
        {
            return ActiveObject.Add(enemy);
        }
        
        public bool RemoveActiveEnemy(Enemy enemy)
        {
            return ActiveObject.Remove(enemy);
        }

        public override Enemy Get()
        {
            Enemy enemy = _bulletPool.Get();
            enemy.transform.SetParent(WorldTransform);
            InitializeEnemy(enemy);
            
            return enemy;
        }

        private void InitializeEnemy(Enemy enemy)
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            EnemySpawned?.Invoke(enemy);
        }

        public override void Release(Enemy enemy)
        {
            _bulletPool.Release(enemy);
            enemy.transform.SetParent(Container);
        }
    }
}