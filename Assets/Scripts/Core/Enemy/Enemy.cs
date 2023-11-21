using Core.Enemy.Agents;
using Infrastructure;
using UnityEngine;

namespace Core.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent _enemyAttackAgent;
        
        private GameManager _gameManager;
        private Transform _target;
        
        public void Construct(GameManager gameManager, Transform transform)
        {
            _gameManager = gameManager;
            _target = transform;
        }

        public void Enable()
        {
            _enemyAttackAgent.SetTarget(_target);
            
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