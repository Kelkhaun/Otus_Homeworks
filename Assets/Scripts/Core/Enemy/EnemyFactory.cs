using System;
using Core.Bullets;
using Core.Character;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Enemy
{
    [Serializable]
    public class EnemyFactory
    {
        [SerializeField] private Enemy _enemyPrefab;
        
        private GameManager _gameManager;
        private Transform _playerTarget;
        private BulletSystem _bulletSystem;

        [Inject]
        public void Construct(BulletSystem bulletSystem, PlayerService playerService, GameManager gameManager)
        {
            _bulletSystem = bulletSystem;
            _gameManager = gameManager;
            _playerTarget = playerService.Player.transform;
        }

        public Enemy Create(Transform container)
        {
            Enemy enemy = Object.Instantiate(_enemyPrefab, container);
            enemy.Construct(_gameManager, _playerTarget, _bulletSystem);
            return enemy;
        }
    }
}