using System.Collections.Generic;
using Core.Enemy;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class EnemyGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private SpawnEnemyObserver _spawnEnemyObserver;
        [SerializeField] private EnemyDeathObserver _enemyDeathObserver;

        public IEnumerable<IGameListener> Install()
        {
            yield return _enemyManager;
            yield return _spawnEnemyObserver;
            yield return _enemyDeathObserver;
        }
    }
}