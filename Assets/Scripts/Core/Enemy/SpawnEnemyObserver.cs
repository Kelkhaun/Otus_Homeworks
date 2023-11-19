using Core.Enemy.Agents;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class SpawnEnemyObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private EnemyPool _enemyPool;

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
        }
    }
}