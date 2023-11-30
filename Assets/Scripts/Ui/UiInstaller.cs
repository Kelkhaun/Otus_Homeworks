using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace Ui
{
    public sealed class UiInstaller : GameInstaller
    {
        [SerializeField, Listener] 
        private PauseButton _pauseButton;
        
        [SerializeField, Listener] 
        private StartGameButtonAdapter _startGameButton;
    }
}