using System;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Input
{
    public sealed class KeyboardInput : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private KeyCode _shootKey = KeyCode.Space;
        [SerializeField] private KeyCode _leftKey = KeyCode.LeftArrow;
        [SerializeField] private KeyCode _rightKey = KeyCode.RightArrow;

        private float _horizontalDirection;

        public event Action<Vector2> OnMove;
        public event Action OnFire;
        
        public void OnUpdate(float deltaTime)
        {
            if (UnityEngine.Input.GetKeyDown(_shootKey))
            {
                OnFire?.Invoke();
            }

            if (UnityEngine.Input.GetKey(_leftKey))
            {
                _horizontalDirection = -1;
                OnMove?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
            else if (UnityEngine.Input.GetKey(_rightKey))
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