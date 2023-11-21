using System;
using Core.Enemy.Agents;
using Core.Pool;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyPool : Pool<Enemy>
    {
        [Header("Spawn")] 
        [SerializeField] private EnemyPositions _enemyPositions;

        private MonoPool<Enemy> _enemyPool;


        private void Awake()
        {
            _enemyPool = new MonoPool<Enemy>(Prefab, Size, Container);
        }

        public bool AddActiveEnemy(Enemy enemy)
        {
            return ActiveObject.Add(enemy);
        }

        public bool RemoveActiveEnemy(Enemy enemy)
        {
            return ActiveObject.Remove(enemy);
        }

        private void InitializeEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(WorldTransform);
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }

        public override Enemy Get()
        {
            Enemy enemy = _enemyPool.Get();
            InitializeEnemy(enemy);

            return enemy;
        }

        public override void Release(Enemy enemy)
        {
            _enemyPool.Release(enemy);
            enemy.transform.SetParent(Container);
        }
    }
}