using Core.Bullets;
using Core.Enemy.Agents;
using Infrastructure;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Enemy
{
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent _enemyAttackAgent;

        private GameManager _gameManager;
        private Transform _target;
        private BulletSystem _bulletSystem;

        public void Construct(GameManager gameManager, Transform transform, BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
            _gameManager = gameManager;
            _target = transform;
        }

        public void Enable()
        {
            _enemyAttackAgent.SetTarget(_target);
            _enemyAttackAgent.Construct(_bulletSystem);

            var listeners = GetComponents<IGameListener>();
            _gameManager.AddListeners(listeners);
        }

        public void Disable()
        {
            var listeners = GetComponents<IGameListener>();
            _gameManager.RemoveListeners(listeners);
        }
    }
}