using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private KeyCode _shootKey = KeyCode.Space;
        [SerializeField] private KeyCode _leftKey = KeyCode.LeftArrow;
        [SerializeField] private KeyCode _rightKey = KeyCode.RightArrow;

        private float _horizontalDirection;

        public event Action<Vector2> Move;
        public event Action Fire;

        private void Update()
        {
            if (Input.GetKeyDown(_shootKey))
            {
                Fire?.Invoke();
            }

            if (Input.GetKey(_leftKey))
            {
                _horizontalDirection = -1;
                Move?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(_rightKey))
            {
                _horizontalDirection = 1;
                Move?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
            else
            {
                _horizontalDirection = 0;
                Move?.Invoke(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
            }
        }
    }
}