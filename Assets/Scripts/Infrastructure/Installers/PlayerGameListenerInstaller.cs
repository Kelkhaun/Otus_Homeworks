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

        public IEnumerable<IGameListener> Install()
        {
            yield return _keyboardInput;
            yield return _playerDeathObserver;
            yield return _inputController;
        }
    }
}