using System.Collections.Generic;

namespace Scripts.Infrastructure.GameSystem
{
    public interface IGameListenerProvider
    {
        IEnumerable<IGameListener> ProvideListeners();
    }
}