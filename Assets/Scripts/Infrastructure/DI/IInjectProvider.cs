using Scripts.Infrastructure.Locator;

namespace Scripts.Infrastructure.DI
{
    public interface IInjectProvider
    {
        void Inject(ServiceLocator serviceLocator);
    }
}