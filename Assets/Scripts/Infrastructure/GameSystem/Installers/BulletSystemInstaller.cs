using Core.Bullets;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public sealed class BulletSystemInstaller : GameInstaller
    {
        [SerializeField] [Listener] private BulletSystem _bulletSystem;
    }
}