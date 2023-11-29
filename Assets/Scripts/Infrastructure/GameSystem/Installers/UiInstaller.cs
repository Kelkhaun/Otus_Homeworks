using Ui;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class UiInstaller : GameInstaller
    {
        [SerializeField] [Listener] private PauseButtonModel _pauseButton;
        [SerializeField] [Listener] private StartGameButtonModel _startGameButton;
    }
}