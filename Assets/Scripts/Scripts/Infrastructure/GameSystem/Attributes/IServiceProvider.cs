using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure.GameSystem.Attributes
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}