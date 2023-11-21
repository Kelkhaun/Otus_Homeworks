using System.Collections.Generic;
using Core.Bullets;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class BulletSystemGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private BulletSystem _bulletSystem;
            
        public IEnumerable<IGameListener> Install()
        {
            yield return _bulletSystem;
        }
    }
}