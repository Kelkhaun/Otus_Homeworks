using Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace Infrastructure.GameSystem
{
    public sealed class GameManagerInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(GameManager))]
        private GameManager _gameManager;
    }
}