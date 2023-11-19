using System.Collections.Generic;
using Core.Character;
using Core.Input;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class PlayerGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private PlayerDeathObserver _playerDeathObserver;

        public List<IGameListener> Install()
        {
            var listeners = new List<IGameListener>
            {
                _inputController,
                _playerDeathObserver,
                _keyboardInput
            };

            return listeners;
        }
    }
}