using Ui;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class UiInstaller : GameInstaller
    {
        [SerializeField] [Listener] private PauseButton _pauseButton;
        [SerializeField] [Listener] private StartGameButton _startGameButton;
    }
}