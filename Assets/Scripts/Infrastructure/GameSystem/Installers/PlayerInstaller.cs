using Core.Character;
using Core.Input;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class PlayerInstaller : GameInstaller
    {
        [SerializeField] [Listener] private InputController _playerInput = new ();
        [SerializeField] [Listener] private KeyboardInput _keyboardInput;
        [SerializeField] [Listener] private PlayerDeathObserver _playerDeathObserver = new();
        [SerializeField] [Service(typeof(PlayerShooter))] private PlayerShooter _playerShooter = new();
    }
}