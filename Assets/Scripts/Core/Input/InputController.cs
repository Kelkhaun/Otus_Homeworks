using System;
using Core.Character;
using Core.Components;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Input
{
    [Serializable]
    public sealed class InputController :
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
        
        private PlayerShooter _playerShooter;

        [Inject]
        public void Construct(PlayerShooter playerShooter)
        {
            _playerShooter = playerShooter;
        }

        public void OnStartGame() => Subscribe();

        public void OnFinishGame() => Unsubscribe();

        public void OnResumeGame() => Subscribe();

        public void OnPauseGame() => Unsubscribe();

        private void Subscribe()
        {
            _keyboardInput.OnMove += _moveComponent.Move;
            _keyboardInput.OnFire += _playerShooter.Fire;
        }

        private void Unsubscribe()
        {
            _keyboardInput.OnMove -= _moveComponent.Move;
            _keyboardInput.OnFire -= _playerShooter.Fire;
        }
    }
}