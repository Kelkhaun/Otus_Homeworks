using Core.Enemy;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class EnemyInstaller : GameInstaller
    {
        [SerializeField] [Service(typeof(EnemyFactory))] private EnemyFactory _enemyFactory = new();
        [SerializeField] [Listener] [Service(typeof(EnemyPool))] private EnemyPool _enemyPool;
        [SerializeField] [Listener] [Service(typeof(EnemyPositions))] private EnemyPositions _enemyPositions = new();
        [SerializeField] [Listener] private EnemySpawnController _enemySpawnController = new();
        [SerializeField] [Listener] [Service(typeof(EnemyManager))] private EnemyManager _enemyManager;
    }
}