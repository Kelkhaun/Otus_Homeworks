using Core.Bullets;
using Core.Components;
using Infrastructure;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform _playerTarget;

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

        public void Spawn()
        {
            Enemy enemy = _enemyPool.Get();

            enemy.Construct(_gameManager, _playerTarget, _bulletSystem);
            enemy.Enable();

            if (_enemyPool.AddActiveEnemy(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying += OnDestroyed;
            }
        }
    }
}