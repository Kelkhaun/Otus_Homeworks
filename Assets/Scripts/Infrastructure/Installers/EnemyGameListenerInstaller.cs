using System.Collections.Generic;
using Core.Enemy;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class EnemyGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private SpawnEnemyObserver _spawnEnemyObserver;
        [SerializeField] private EnemySpawnObserver _enemySpawnObserver;
        [SerializeField] private EnemyDeathObserver _enemyDeathObserver;
    
        public List<IGameListener> Install()
        {
            var listeners = new List<IGameListener>
            {
                _enemyManager,
                _spawnEnemyObserver,
                _enemySpawnObserver,
                _enemyDeathObserver
            };

            return listeners;
        }
    }
}