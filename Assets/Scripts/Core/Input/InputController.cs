using Core.Character;
using Core.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Input
{
    public sealed class InputController : MonoBehaviour, 
        IGameStartListener, 
        IGameFinishListener, 
        IGamePauseListener, 
        IGameResumeListener
    {
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
        [FormerlySerializedAs("_playerFireListener")] [SerializeField] private PlayerShooter playerShooter;

        public void OnStartGame() => Subscribe();

        public void OnFinishGame() => Unsubscribe();

        public void OnResumeGame() => Subscribe();

        public void OnPauseGame() => Unsubscribe();

        private void Subscribe()
        {
            _keyboardInput.OnMove += _moveComponent.Move;
            _keyboardInput.OnFire += playerShooter.Fire;
        }

        private void Unsubscribe()
        {
            _keyboardInput.OnMove -= _moveComponent.Move;
            _keyboardInput.OnFire -= playerShooter.Fire;
        }
    }
}