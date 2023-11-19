using System.Collections.Generic;
using Core.Enemy;
using Core.Enemy.Agents;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class EnemyGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private SpawnEnemyObserver _spawnEnemyObserver;
    
        public List<IGameListener> Install()
        {
            var listeners = new List<IGameListener>
            {
                _enemyManager,
                _spawnEnemyObserver,
            };

            return listeners;
        }
    }
}