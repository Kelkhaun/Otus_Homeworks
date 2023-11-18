using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class TimeScaleListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private TimeScaleListener _timeScaleListener;
            
        public IGameListener Install()
        {
            return _timeScaleListener;
        }
    }
}