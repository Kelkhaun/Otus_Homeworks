using Core.Components;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private MoveComponent _moveComponent;

        private Vector2 _destination;
        private float _minDistance = 0.25f;

        public bool IsReached { get; private set; }

        public void OnFixedUpdate(float deltaTime)
        {
            if (IsReached)
            {
                return;
            }

            var vector = _destination - (Vector2) transform.position;

            if (vector.magnitude <= _minDistance)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.Move(direction);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }
    }
}