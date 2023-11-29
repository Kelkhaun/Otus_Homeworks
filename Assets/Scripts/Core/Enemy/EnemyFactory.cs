using System;
using Core.Bullets;
using Infrastructure.GameSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Enemy
{
    [Serializable]
    public class EnemyFactory
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private Transform _playerTarget;
        [SerializeField] private Enemy _enemyPrefab;

        public Enemy Create(Transform container)
        {
            Enemy enemy = Object.Instantiate(_enemyPrefab, container);
            enemy.Construct(_gameManager, _playerTarget, _bulletSystem);
            return enemy;
        }
    }
}