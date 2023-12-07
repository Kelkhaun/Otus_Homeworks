using System.Collections.Generic;

namespace Infrastructure.GameSystem
{
    public interface IGameListenerProvider
    {
        IEnumerable<IGameListener> ProvideListeners();
    }
}