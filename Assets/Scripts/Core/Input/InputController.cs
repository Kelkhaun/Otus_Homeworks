using Core.Character;
using Core.Components;
using Infrastructure.DI;
using Infrastructure.GameSystem;

namespace Core.Input
{
    public sealed class InputController :
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        private KeyboardInput _keyboardInput;
        private MoveComponent _moveComponent;
        private PlayerShooter _playerShooter;

        [Inject]
        public void Construct(PlayerShooter playerShooter, KeyboardInput keyboardInput, PlayerService playerService)
        {
            _moveComponent = playerService.Player.GetComponent<MoveComponent>();
            _playerShooter = playerShooter;
            _keyboardInput = keyboardInput;
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