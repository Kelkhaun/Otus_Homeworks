using System;
using Infrastructure.DI;
using Sirenix.OdinInspector;
using UpgradePopup.Factory;
using UpgradePopup.Presenter;
using UpgradePopup.UpgradePopups;

namespace UpgradePopup
{
    [Serializable]
    public sealed class UpgradePopupShower
    {
        private UpgradePresenterFactory _upgradePresenterFactory;
        private UserInfoUpgradePopup _userInfoUpgradePopup;
        private CharacterLevelUpgradePopup _characterLevelUpgradePopup;
        private CharacterInfoUpgradePopup _characterInfoUpgradePopup;

        [Inject]
        public void Construct(UpgradePresenterFactory factory, UserInfoUpgradePopup userInfoUpgradePopup,
            CharacterLevelUpgradePopup characterLevelUpgradePopup, CharacterInfoUpgradePopup characterInfoUpgradePopup)
        {
            _characterInfoUpgradePopup = characterInfoUpgradePopup;
            _characterLevelUpgradePopup = characterLevelUpgradePopup;
            _userInfoUpgradePopup = userInfoUpgradePopup;
            _upgradePresenterFactory = factory;
        }

        [Button]
        public void Show()
        {
            IUpgradePresenter presenter = _upgradePresenterFactory.Create();
            _userInfoUpgradePopup.Show(presenter);
            _characterLevelUpgradePopup.Show(presenter);
            _characterInfoUpgradePopup.Show(presenter);
        }
    }
}