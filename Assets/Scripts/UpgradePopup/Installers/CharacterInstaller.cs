using Scripts.Infrastructure;
using Scripts.Infrastructure.GameSystem.Attributes;
using UnityEngine;

namespace Scripts.UpgradePopup.Installers
{
    public class CharacterInstaller : GameInstaller
    {
        [SerializeField, Service(typeof(Character.Character))]
        private Character.Character _character;
    }
}