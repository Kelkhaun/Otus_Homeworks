using ShootEmUp;
using UnityEngine;

public class SpawnEnemyObserver : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private EnemyPool _enemyPool;
    
    private void OnEnable()
    {
        _enemyPool.EnemySpawned += OnEnemySpawn;
    }

    private void OnDisable()
    {
        _enemyPool.EnemySpawned -= OnEnemySpawn;
    }

    private void OnEnemySpawn(Enemy enemy)
    {
        enemy.GetComponent<EnemyAttackAgent>().SetTarget(_player);
    }
}