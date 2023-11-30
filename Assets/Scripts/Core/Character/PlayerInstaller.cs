using Core.Input;
using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace Core.Character
{
    public sealed class PlayerInstaller : GameInstaller
    {
        [Listener] 
        private InputController _playerInput = new();

        [SerializeField, Listener, Service(typeof(KeyboardInput))]
        private KeyboardInput _keyboardInput = new();

        [SerializeField, Listener] 
        private PlayerDeathObserver _playerDeathObserver = new();

        [SerializeField, Service(typeof(PlayerShooter))]
        private PlayerShooter _playerShooter = new();

        [SerializeField, Service(typeof(KeyboardMap))]
        private KeyboardMap _keyboardMap;
        
        [SerializeField, Service(typeof(PlayerService))]
        private PlayerService _playerService = new();
    }
}