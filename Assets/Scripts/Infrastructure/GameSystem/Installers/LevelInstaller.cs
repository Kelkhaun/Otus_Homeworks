using Core.Level;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
  public sealed class LevelInstaller : GameInstaller
  {
    [SerializeField] [Listener] private LevelBackground _levelBackground = new();
    [SerializeField] [Service(typeof(Transform))] private Transform _levelBackgroundTransform;
    [SerializeField] [Service(typeof(LevelBounds))] private LevelBounds _levelBounds = new();
  }
}
