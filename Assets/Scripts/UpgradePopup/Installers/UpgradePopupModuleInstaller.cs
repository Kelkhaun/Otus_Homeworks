using Scripts.Infrastructure;
using Scripts.Infrastructure.GameSystem.Attributes;
using Scripts.UpgradePopup.Factory;
using Scripts.UpgradePopup.Pool;
using Scripts.UpgradePopup.UpgradePopups;
using UnityEngine;

namespace Scripts.UpgradePopup.Installers
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