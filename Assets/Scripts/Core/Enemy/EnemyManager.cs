using System;
using Core.Components;
using Infrastructure.DI;
using UnityEngine;

namespace Core.Enemy
{
    [Serializable]
    public sealed class EnemyManager
    {
        private EnemyPool _enemyPool;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(EnemyFactory enemyFactory, EnemyPool enemyPool)
        {
            _enemyFactory = enemyFactory;
            _enemyPool = enemyPool;
        }

        public void Spawn()
        {
            Enemy enemy = _enemyFactory.GetEnemy();

            if (_enemyPool.AddActiveEnemy(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying += OnDestroyed;
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.Disable();

            if (_enemyPool.RemoveActiveEnemy(enemyComponent))
            {
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying -= OnDestroyed;
                _enemyPool.Release(enemyComponent);
            }
        }
    }
}