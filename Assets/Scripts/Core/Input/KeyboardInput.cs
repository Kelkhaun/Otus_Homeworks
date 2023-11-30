using System;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Input
{
    [Serializable]
    public sealed class KeyboardInput : IGameUpdateListener
    {
        private KeyboardMap _keyboardMap;
        private float _horizontalDirection;

        public event Action<Vector2> OnMove;
        public event Action OnFire;

        [Inject]
        private void Construct(KeyboardMap keyboardMap)
        {
            _keyboardMap = keyboardMap;
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (UnityEngine.Input.GetKeyDown(_keyboardMap.ShootKey))
            {
                OnFire?.Invoke();
            }

            if (UnityEngine.Input.GetKey(_keyboardMap.LeftKey))
            {
                _horizontalDirection = -1;
                OnMove?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
            else if (UnityEngine.Input.GetKey(_keyboardMap.RightKey))
            {
                _horizontalDirection = 1;
                OnMove?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
            else
            {
                _horizontalDirection = 0;
                OnMove?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
        }
    }
}

