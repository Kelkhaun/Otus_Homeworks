using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace UpgradePopup.Installers
{
    public sealed class CharacterInstaller : GameInstaller
    {
        [SerializeField, Service(typeof(Character.Character))]
        private Character.Character _character;
    }
}