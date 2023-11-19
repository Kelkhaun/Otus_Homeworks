using System.Collections.Generic;
using Core.Bullets;
using Ui;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class UiGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private PauseButton _pauseButton;
        [SerializeField] private GameButton _startGameButton;

        public List<IGameListener> Install()
        {
            var listeners = new List<IGameListener>
            {
                _pauseButton,
                _startGameButton,
            };

            return listeners;
        }
    }
}