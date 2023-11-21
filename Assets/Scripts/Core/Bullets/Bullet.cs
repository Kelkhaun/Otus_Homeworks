using System;
using Core.Components;
using UnityEngine;

namespace Core.Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private bool IsPlayer { get; set; }
        private int Damage { get; set; }

        public event Action<Bullet, GameObject> OnCollisionEntered;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision.gameObject);
        }

        public void SetDamage(int damage)
        {
            Damage = damage;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public void SetIsPlayer(bool isPlayer)
        {
            IsPlayer = isPlayer;
        }

        public void TryTakeDamage(GameObject collisionObject)
        {
            if (!collisionObject.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (collisionObject.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(Damage);
            }
        }
    }
}