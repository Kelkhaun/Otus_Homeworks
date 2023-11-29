using Core.Bullets;
using Core.Components;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private float _countdown;

        private Transform _target;
        private float _force = 2.0f;
        private float _currentTime;
        private BulletSystem _buleltSystem;

        public void Construct(BulletSystem bulletSystem)
        {
            _buleltSystem = bulletSystem;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }

            if (!_target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            _currentTime -= deltaTime;

            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2) _target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire(startPosition, direction);
        }

        private void OnFire(Vector2 position, Vector2 direction)
        {
            _buleltSystem.Fire(new BulletSystem.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * _force
            });
        }
    }
}