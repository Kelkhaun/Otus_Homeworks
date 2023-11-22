using Core.Enemy.Agents;
using Core.Pool;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class EnemyPool : MonoPool<Enemy>
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions _enemyPositions;

        public bool AddActiveEnemy(Enemy enemy)
        {
            return ActiveObject.Add(enemy);
        }

        public bool RemoveActiveEnemy(Enemy enemy)
        {
            return ActiveObject.Remove(enemy);
        }

        public override Enemy Get()
        {
            Enemy enemy = base.Get();
            InitializeEnemy(enemy);

            return enemy;
        }

        public override void Release(Enemy enemy)
        {
            base.Release(enemy);
            enemy.transform.SetParent(Container);
        }

        private void InitializeEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(WorldTransform);
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }
    }
}