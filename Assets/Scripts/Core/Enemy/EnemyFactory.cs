using System;
using Core.Bullets;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Enemy
{
    [Serializable]
    public class EnemyFactory
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Transform _playerTarget;
        
        public Enemy GetEnemy()
        {
            Enemy enemy = _enemyPool.Get();

            enemy.Construct(_gameManager, _playerTarget, _bulletSystem);
            enemy.Enable();

            return enemy;
        }
    }
}