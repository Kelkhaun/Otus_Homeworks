using Ui;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class GameStartButtonInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private StartGameButton _startGameButton;
            
        public IGameListener Install()
        {
            return _startGameButton;
        }
    }
}