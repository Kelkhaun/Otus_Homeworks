using Scripts.Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace Scripts.Infrastructure.GameSystem
{
    public sealed class GameManagerInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(GameManager))]
        private GameManager _gameManager;
    }
}