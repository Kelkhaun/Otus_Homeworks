using System;
using Core.Enemy.Agents;
using Core.Pool;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyPool : Pool<Core.Enemy.Enemy>
    {
        [Header("Spawn")] 
        [SerializeField] private EnemyPositions _enemyPositions;

        private MonoPool<Core.Enemy.Enemy> _enemyPool;

        public event Action<Core.Enemy.Enemy> OnEnemySpawned;

        private void Awake()
        {
            _enemyPool = new MonoPool<Core.Enemy.Enemy>(Prefab, Size, Container);
        }

        public bool AddActiveEnemy(Core.Enemy.Enemy enemy)
        {
            return ActiveObject.Add(enemy);
        }

        public bool RemoveActiveEnemy(Core.Enemy.Enemy enemy)
        {
            return ActiveObject.Remove(enemy);
        }

        private void InitializeEnemy(Core.Enemy.Enemy enemy)
        {
            enemy.transform.SetParent(WorldTransform);
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            OnEnemySpawned?.Invoke(enemy);
        }

        public override Core.Enemy.Enemy Get()
        {
            Core.Enemy.Enemy enemy = _enemyPool.Get();
            InitializeEnemy(enemy);

            return enemy;
        }

        public override void Release(Core.Enemy.Enemy enemy)
        {
            _enemyPool.Release(enemy);
            enemy.transform.SetParent(Container);
        }
    }
}