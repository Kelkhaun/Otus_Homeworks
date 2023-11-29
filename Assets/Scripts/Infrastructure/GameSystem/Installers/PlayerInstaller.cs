using Core.Character;
using Core.Components;
using Core.Input;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class PlayerInstaller : GameInstaller
    {
        [SerializeField] [Service(typeof(MoveComponent))] private MoveComponent _playerMoveComponent;
        [Listener] private InputController _playerInput = new();
        [SerializeField] [Listener][Service(typeof(KeyboardInput))] private KeyboardInput _keyboardInput = new();
        [SerializeField] [Listener] private PlayerDeathObserver _playerDeathObserver = new();
        [SerializeField] [Service(typeof(PlayerShooter))] private PlayerShooter _playerShooter = new();
    }
}