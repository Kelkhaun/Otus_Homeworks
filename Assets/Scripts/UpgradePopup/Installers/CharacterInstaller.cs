using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace UpgradePopup.Installers
{
    public sealed class CharacterInstaller : GameInstaller
    {
        [SerializeField, Service(typeof(CharacterScripts.Character))]
        private CharacterScripts.Character _character;
    }
}