using System;
using System.Collections.Generic;

namespace Infrastructure.GameSystem.Installers
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}