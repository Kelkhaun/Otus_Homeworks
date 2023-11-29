using Core.Enemy;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class EnemyInstaller : GameInstaller
    {
        [SerializeField] [Listener] private EnemySpawnController _enemySpawnController;
    }
}