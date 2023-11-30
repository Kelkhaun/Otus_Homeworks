using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using Infrastructure.Locator;
using UnityEngine;

namespace Core.Level
{
    public sealed class LevelInstaller : GameInstaller
    {
        [SerializeField, Listener] 
        private LevelBackground _levelBackground = new();

        [SerializeField]
        private Transform _levelBackgroundTransform;

        [SerializeField, Service(typeof(LevelBounds))]
        private LevelBounds _levelBounds = new();

        public override void Inject(ServiceLocator serviceLocator)
        {
            _levelBackground.Construct(_levelBackgroundTransform);
        }
    }
}