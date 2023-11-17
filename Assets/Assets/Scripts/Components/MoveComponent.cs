using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed = 5.0f;

        public void OnMove(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}