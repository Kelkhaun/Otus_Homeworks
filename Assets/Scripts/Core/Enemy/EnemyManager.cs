using Core.Components;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private EnemyFactory _enemyFactory;

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