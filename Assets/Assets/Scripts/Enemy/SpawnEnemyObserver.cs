using Assets.Scripts.Enemy.Agents;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public sealed class SpawnEnemyObserver : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private EnemyPool _enemyPool;
    
        private void OnEnable()
        {
            _enemyPool.OnEnemySpawned += OnEnemySpawn;
        }

        private void OnDisable()
        {
            _enemyPool.OnEnemySpawned -= OnEnemySpawn;
        }

        private void OnEnemySpawn(Enemy enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_player);
        }
    }
}