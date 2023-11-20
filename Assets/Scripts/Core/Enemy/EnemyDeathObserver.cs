using Core.Enemy.Agents;
using Infrastructure;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyDeathObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private EnemyManager _enemyManager;

        public void OnStartGame()
        {
            _enemyManager.OnEnemyDying += OnEnemyDying;
        }

        public void OnFinishGame()
        {
            _enemyManager.OnEnemyDying -= OnEnemyDying;
        }
        
        private void OnEnemyDying(Enemy enemy)
        {
            EnemyAttackAgent enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();
            EnemyMoveAgent enemyMoveAgent = enemy.GetComponent<EnemyMoveAgent>();
            
            _gameManager.RemoveListener(enemyMoveAgent);
            _gameManager.RemoveListener(enemyAttackAgent);
        }
    }
}