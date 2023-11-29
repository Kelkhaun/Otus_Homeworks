using Infrastructure.Locator;
using UnityEngine;

namespace Infrastructure.GameSystem.Installers
{
    public class ServiceLocatorInstaller : MonoBehaviour
    {
        [SerializeField] private ServiceLocator _serviceLocator;
        [SerializeField] private MonoBehaviour[] _providers;

        private void Awake()
        {
            foreach (var provider in _providers)
            {
                if (provider is IServiceProvider tProvider)
                {
                    var services = tProvider.ProvideServices();

                    foreach (var (type, service) in services)
                    {
                        _serviceLocator.BindService(type, service);
                    }
                }
            }
        }
    }
}