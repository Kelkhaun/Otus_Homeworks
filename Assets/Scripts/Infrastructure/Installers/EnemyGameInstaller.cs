using System.Collections.Generic;
using Core.Enemy;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class EnemyGameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EnemySpawnController _enemyGameInstaller;

        public IEnumerable<IGameListener> Install()
        {
            yield return _enemyGameInstaller;
        }
    }
}