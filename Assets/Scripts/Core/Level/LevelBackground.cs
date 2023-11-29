using System;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Level
{
    [Serializable]
    public sealed class LevelBackground : IGameStartListener,IGameFixedUpdateListener
    {
        [SerializeField] private Params _params;

        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;
        private Transform _transform;

        [Inject]
        public void Construct(Transform levelBackgroundTransform)
        {
            _transform = levelBackgroundTransform;

        }
        
        public void OnStartGame()
        {
            _startPositionY = _params.StartPositionY;
            _endPositionY = _params.EndPositionY;
            _movingSpeedY = _params.MovingSpeedY;
            var position = _transform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (_transform.position.y <= _endPositionY)
            {
                _transform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _transform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [field: SerializeField] public float StartPositionY { get; private set; }
            [field: SerializeField] public float EndPositionY { get; private set; }
            [field: SerializeField] public float MovingSpeedY { get; private set; }
        }
    }
}