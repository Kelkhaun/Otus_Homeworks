using System;
using UnityEngine;

namespace Core.Components
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        [SerializeField] private int _hitPoints;

        public event Action<GameObject> OnEnemyDying;

        public bool IsHitPointsExists()
        {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;

            if (_hitPoints <= 0)
            {
                OnEnemyDying?.Invoke(gameObject);
            }
        }
    }
}