using System;
using UnityEngine;
using UnityEngine.UI;
using UpgradePopup.Pool;
using UpgradePopup.Presenter;

namespace UpgradePopup.UpgradePopups
{
    public sealed class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private CharacterInfoView _characterInfoView;
        [SerializeField] private CharacterLevelView _characterLevelView;
        [SerializeField] private Button _closeButton;

        private CharacterStatPool _characterStatPool;    // через констракт

        private IUpgradePresenter _presenter;

        public void Show(object args)
        {
            if (args is not IUpgradePresenter presenter)
            {
                throw new Exception("Expected Product Presenter");
            }

            _presenter = presenter;
            gameObject.SetActive(true);
            _characterInfoView.Show(_presenter.PlayerInfoPresenter);
            _characterLevelView.Show(_presenter.LevelInfoPresenter);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
            gameObject.SetActive(false);
        }
    }
}