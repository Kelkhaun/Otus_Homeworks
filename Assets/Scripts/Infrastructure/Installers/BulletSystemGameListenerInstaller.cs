using System.Collections.Generic;
using Core.Bullets;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class BulletSystemGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private BulletSystem _bulletSystem;
            
        public List<IGameListener> Install()
        {
            var listeners = new List<IGameListener>
            {
                _bulletSystem,
            };

            return listeners;
        }
    }
}