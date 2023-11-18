using Core.Character;
using Core.Components;
using UnityEngine;

namespace Core.Input
{
    public sealed class InputController : MonoBehaviour, IGameStartListener, IGameFinishListener, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private PlayerFireListener _playerFireListener;

        public void OnStartGame() => Subscribe();

        public void OnFinishGame() => Unsubscribe();

        public void OnResumeGame() => Subscribe();

        public void OnPauseGame() => Unsubscribe();

        private void Subscribe()
        {
            _keyboardInput.OnMove += _moveComponent.OnMove;
            _keyboardInput.OnFire += _playerFireListener.OnFire;
        }

        private void Unsubscribe()
        {
            _keyboardInput.OnMove -= _moveComponent.OnMove;
            _keyboardInput.OnFire -= _playerFireListener.OnFire;
        }
    }
}