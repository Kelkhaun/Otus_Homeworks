using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using UnityEngine;
using UpgradePopup.Factory;
using UpgradePopup.Pool;
using UpgradePopup.UpgradePopups;

namespace UpgradePopup.Installers
{
    public sealed class UpgradePopupModuleInstaller : GameInstaller
    {
        [SerializeField, Service(typeof(UserInfoUpgradePopup))]
        private UserInfoUpgradePopup _userInfoUpgradePopup;

        [SerializeField, Service(typeof(CharacterLevelUpgradePopup))]
        private CharacterLevelUpgradePopup _characterLevelUpgradePopup;

        [SerializeField, Service(typeof(CharacterInfoUpgradePopup))]
        private CharacterInfoUpgradePopup _characterInfoUpgradePopup;

        [Service(typeof(UpgradePresenterFactory))]
        private UpgradePresenterFactory _upgradePresenterFactory = new();

        [SerializeField, Service(typeof(CharacterStatViewFactory))]
        private CharacterStatViewFactory _characterStatViewFactory = new();

        [Service(typeof(CharacterStatPool))] 
        private CharacterStatPool _characterStatPool = new();

        [SerializeField]
        private UpgradePopupShower _upgradePopupShower = new();
    }
}