using Core.Enemy.Agents;
using Infrastructure;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class SpawnEnemyObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private GameManager _gameManager;

        public void OnStartGame()
        {
            _enemyPool.OnEnemySpawned += OnEnemySpawn;
        }

        public void OnFinishGame()
        {
            _enemyPool.OnEnemySpawned -= OnEnemySpawn;
        }

        private void OnEnemySpawn(Enemy enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_player);
            
            EnemyAttackAgent enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
            EnemyMoveAgent enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();

            _gameManager.AddListener(enemyAttackAgent);
            _gameManager.AddListener(enemyMoveAgent);
        }
    }
}