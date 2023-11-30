using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace Core.Bullets
{
    public sealed class BulletSystemInstaller : GameInstaller
    {
        [SerializeField, Listener, Service(typeof(BulletSystem))]
        private BulletSystem _bulletSystem = new();
        
        [SerializeField, Listener, Service(typeof(BulletPool))]
        private BulletPool _bulletPool = new();
    }
}