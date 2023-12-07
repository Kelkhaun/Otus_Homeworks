using System;
using UnityEngine;
using UpgradePopup.Presenter;

namespace UpgradePopup.UpgradePopups
{
    public sealed class CharacterInfoUpgradePopup : MonoBehaviour
    {
        private IUpgradePresenter _presenter;

        public void Show(object args)
        {
            if (args is not IUpgradePresenter presenter)
            {
                throw new Exception("Expected Product Presenter");
            }

            _presenter = presenter;
            _presenter.Enable();
            gameObject.SetActive(true);
        }
    }
}