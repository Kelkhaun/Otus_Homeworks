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
        private CharacterPopup _characterPopup;

        [Inject]
        public void Construct(UpgradePresenterFactory factory, CharacterPopup characterPopup)
        {
            _characterPopup = characterPopup;
            _upgradePresenterFactory = factory;
        }

        [Button]
        public void Show()
        {
            IUpgradePresenter presenter = _upgradePresenterFactory.Create();
            _characterPopup.Show(presenter);
        }
    }
}