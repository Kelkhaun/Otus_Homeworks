using System;
using Core.Bullets;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Enemy
{
    [Serializable]
    public class EnemyFactory
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform _playerTarget;
        [SerializeField] private Enemy _enemyPrefab;
        
        private BulletSystem _bulletSystem;

        [Inject]
        public void Construct(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }
        
        public Enemy Create(Transform container)
        {
            Enemy enemy = Object.Instantiate(_enemyPrefab, container);
            enemy.Construct(_gameManager, _playerTarget, _bulletSystem);
            return enemy;
        }
    }
}