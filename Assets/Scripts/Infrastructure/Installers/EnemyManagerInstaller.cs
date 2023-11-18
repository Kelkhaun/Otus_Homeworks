using Core.Enemy;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class EnemyManagerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EnemyManager _enemyManager;
    
        public IGameListener Install()
        {
            return _enemyManager;
        }
    }
}