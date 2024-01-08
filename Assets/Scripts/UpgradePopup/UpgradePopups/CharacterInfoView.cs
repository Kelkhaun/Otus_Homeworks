using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UpgradePopup.Presenter;

namespace UpgradePopup.UpgradePopups
{
    public sealed class CharacterInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _profileIcon;
        [SerializeField] private Button _closeButton;

        private IUpgradeInfoPresenter _presenter;

        public void Show(object args)
        {
            if (args is not IUpgradeInfoPresenter presenter)
            {
                throw new Exception("Expected Upgrade Presenter");
            }

            _presenter = presenter;

            gameObject.SetActive(true);

            _name.SetText(_presenter.Name);
            _description.SetText(_presenter.Description);
            _profileIcon.sprite = _presenter.ProfileIcon;

            _closeButton.onClick.AddListener(OnCloseButtonClicked);
            _presenter.OnNameChanged += OnNameChanged;
            _presenter.OnDescriptionChanged += OnDescriptionChanged;
            _presenter.OnIconChanged += OnIconChanged;
        }

        public void OnCloseButtonClicked()
        {
            _presenter.Disable();
            gameObject.SetActive(false);
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            _presenter.OnNameChanged -= OnNameChanged;
            _presenter.OnDescriptionChanged -= OnDescriptionChanged;
            _presenter.OnIconChanged -= OnIconChanged;
        }

        private void OnDescriptionChanged(string desciption)
        {
            _description.SetText(desciption);
        }

        private void OnNameChanged(string name)
        {
            _name.SetText(name);
        }

        private void OnIconChanged(Sprite sprite)
        {
            _profileIcon.sprite = sprite;
        }
    }
}