using System.Collections.Generic;

namespace Infrastructure.Installers
{
    public interface IInstaller
    {
        List<IGameListener> Install();
    }
}