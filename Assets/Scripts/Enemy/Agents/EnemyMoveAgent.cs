using Assets.Scripts.Components;
using UnityEngine;

namespace Assets.Scripts.Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private Vector2 _destination;
        private float _minDistance = 0.25f;

        public bool IsReached { get; private set; }

        private void FixedUpdate()
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
            _moveComponent.OnMove(direction);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }
    }
}