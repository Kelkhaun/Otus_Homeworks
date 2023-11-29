using Core.Bullets;
using Infrastructure.GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
      [ShowInInspector]  [SerializeField] private Transform _playerTarget;

        public Enemy GetEnemy()
        {
            Enemy enemy = _enemyPool.Get();

            enemy.Construct(_gameManager, _playerTarget, _bulletSystem);
            enemy.Enable();

            return enemy;
        }
    }
}