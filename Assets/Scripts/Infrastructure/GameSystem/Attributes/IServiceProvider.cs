using System;
using System.Collections.Generic;

namespace Infrastructure.GameSystem.Attributes
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}