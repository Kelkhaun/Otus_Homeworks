using System.Collections.Generic;

namespace Infrastructure.Installers
{
    public interface IInstaller
    {
        IEnumerable<IGameListener> Install();
    }
}