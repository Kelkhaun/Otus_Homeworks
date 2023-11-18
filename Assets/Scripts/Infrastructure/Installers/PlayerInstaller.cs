using Core.Input;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class PlayerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private InputController _inputController;
    
        public IGameListener Install()
        {
            return _inputController;
        }
    }
}