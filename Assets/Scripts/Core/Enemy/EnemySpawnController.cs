using System.Collections;
using Infrastructure.GameSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Enemy
{
    public sealed class EnemySpawnController : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private EnemyManager _enemyManager;

        private Coroutine _spawnEnemyRoutine;
        private int _timeBetweenSpawn = 1;
        private bool _canSpawn = true;

        public void OnStartGame()
        {
            _spawnEnemyRoutine = StartCoroutine(SpawnEnemyRoutine());
        }

        public void OnFinishGame()
        {
            StopCoroutine(_spawnEnemyRoutine);
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            while (_canSpawn)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);
                _enemyManager.Spawn();
            }
        }
    }
}