using System;
using System.Collections;
using Core.Bullets;
using Core.Components;
using Core.Enemy.Agents;
using Infrastructure;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyManager : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform _playerTarget;

        private Coroutine _spawnEnemyRoutine;
        private int _timeBetweenSpawn = 1;
        private float _force = 2.0f;
        private bool _canSpawn = true;

        public event Action<Enemy> OnEnemySpawn;
        public event Action<Enemy> OnEnemyDying;

        public void OnStartGame()
        {
            _spawnEnemyRoutine = StartCoroutine(SpawnEnemyRoutine());
        }

        public void OnFinishGame()
        {
            StopCoroutine(_spawnEnemyRoutine);
        }

        private void OnDestroyed(GameObject enemy)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();

            if (_enemyPool.RemoveActiveEnemy(enemyComponent))
            {
                EnemyAttackAgent enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();

                enemyComponent.Disable();
                OnEnemyDying?.Invoke(enemyComponent);
                enemyAttackAgent.OnFire -= OnFire;
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying -= OnDestroyed;

                _enemyPool.Release(enemyComponent);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.Fire(new BulletSystem.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * _force
            });
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            while (_canSpawn)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);
                Enemy enemy = _enemyPool.Get();

                enemy.Construct(_gameManager, _playerTarget);
                enemy.Enable();

                if (_enemyPool.AddActiveEnemy(enemy))
                {
                    EnemyAttackAgent enemyAttackAgent = enemy.GetComponent<EnemyAttackAgent>();

                    OnEnemySpawn?.Invoke(enemy);
                    enemyAttackAgent.OnFire += OnFire;
                    enemy.GetComponent<HitPointsComponent>().OnEnemyDying += OnDestroyed;
                }
            }
        }
    }
}