using Infrastructure.Locator;

namespace Infrastructure.DI
{
    public interface IInjectProvider
    {
        void Inject(ServiceLocator serviceLocator);
    }
}