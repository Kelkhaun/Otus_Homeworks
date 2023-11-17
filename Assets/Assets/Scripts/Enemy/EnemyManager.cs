using System.Collections;
using Assets.Scripts.Bullets;
using Assets.Scripts.Components;
using Assets.Scripts.Enemy.Agents;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        private int _timeBetweenSpawn = 1;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);
                Enemy enemy = _enemyPool.Get();

                if (_enemyPool.AddActiveEnemy(enemy))
                {
                    enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                    enemy.GetComponent<HitPointsComponent>().OnEnemyDying += OnDestroyed;
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            Enemy
                enemyComponent = enemy.GetComponent<Enemy>();

            if (_enemyPool.RemoveActiveEnemy(enemyComponent))
            {
                enemy.GetComponent<HitPointsComponent>().OnEnemyDying -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

                _enemyPool.Release(enemyComponent);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * 2.0f
            });
        }
    }
}