using Core.Enemy;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class EnemyInstaller : GameInstaller
    {
        [SerializeField] [Service(typeof(EnemyFactory))] private EnemyFactory _enemyFactory = new();
        [SerializeField] [Service(typeof(EnemyPool))]private EnemyPool _enemyPool;
        [Listener] private EnemySpawnController _enemySpawnController = new();
        [Listener] [Service(typeof(EnemyManager))] private EnemyManager _enemyManager;
        [SerializeField] [Listener][Service(typeof(EnemyPositions))] private EnemyPositions _enemyPositions = new();
    }
}