using Assets.Scripts.Character;
using Assets.Scripts.Components;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public sealed class InputController : MonoBehaviour
    {
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PlayerFireListener _playerFireListener;

        private void OnEnable()
        {
            _keyboardInput.OnMove += _moveComponent.OnMove;
            _keyboardInput.OnFire += _playerFireListener.OnFire;
        }

        private void OnDisable()
        {
            _keyboardInput.OnMove -= _moveComponent.OnMove;
            _keyboardInput.OnFire -= _playerFireListener.OnFire;
        }
    }
}