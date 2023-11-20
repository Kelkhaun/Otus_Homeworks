using Core.Enemy.Agents;
using Infrastructure;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemySpawnObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private EnemyManager _enemyManager;

        public void OnStartGame()
        {
            _enemyManager.OnEnemySpawn += OnEnemySpawn;
        }

        public void OnFinishGame()
        {
            _enemyManager.OnEnemySpawn -= OnEnemySpawn;
        }

        private void OnEnemySpawn(Enemy enemy)
        {
            EnemyAttackAgent enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
            EnemyMoveAgent enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();

            _gameManager.AddListener(enemyAttackAgent);
            _gameManager.AddListener(enemyMoveAgent);
        }
    }
}