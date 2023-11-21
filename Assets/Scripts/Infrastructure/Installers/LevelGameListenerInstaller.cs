using System.Collections.Generic;
using Core.Level;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class LevelGameListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private LevelBackground _levelBackground;
            
        public IEnumerable<IGameListener> Install()
        {
            yield return _levelBackground;
        }
    }
}
