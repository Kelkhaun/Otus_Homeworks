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

        [Inject]
        public void Construct(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public void Spawn()
        {
            Enemy enemy = _enemyPool.Get();

            if (_enemyPool.AddActiveEnemy(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying += OnDestroyed;
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();

            if (_enemyPool.RemoveActiveEnemy(enemyComponent))
            {
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying -= OnDestroyed;
                _enemyPool.Release(enemyComponent);
            }
        }
    }
}