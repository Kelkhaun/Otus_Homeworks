using System.Collections.Generic;
using Core.Enemy;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class EnemyGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EnemyManager _enemyManager;

        public IEnumerable<IGameListener> Install()
        {
            yield return _enemyManager;
        }
    }
}