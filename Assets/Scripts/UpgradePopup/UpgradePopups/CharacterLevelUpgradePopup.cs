using System;
using Scripts.UpgradePopup.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UpgradePopup.UpgradePopups
{
    public sealed class CharacterLevelUpgradePopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevel;
        [SerializeField] private TMP_Text _currentExperience;
        [SerializeField] private TMP_Text _requiredExperience;
        [SerializeField] private Button _levelUpButton;
        [field: SerializeField] private Button CloseButton;

        private IUpgradePresenter _presenter;

        public void Show(object args)
        {
            if (args is not IUpgradePresenter presenter)
            {
                throw new Exception("Expected Product Presenter");
            }

            _presenter = presenter;
            gameObject.SetActive(true);

            _currentLevel.SetText(_presenter.CurrentLevel);
            _currentExperience.SetText(_presenter.CurrentExperience);
            _requiredExperience.SetText(_presenter.RequiredExperience);
            _levelUpButton.interactable = _presenter.IsLevelUpButtonInteractable;
            presenter.OnExperienceChanged += OnExperienceChanged;
            presenter.OnLevelUp += OnLevelUp;
            _levelUpButton.onClick.AddListener(OnLevelUpButtonClicked);
            CloseButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            gameObject.SetActive(false);
            _presenter.OnExperienceChanged -= OnExperienceChanged;
            _presenter.OnLevelUp -= OnLevelUp;
            _levelUpButton.onClick.RemoveListener(OnLevelUpButtonClicked);
        }

        private void OnLevelUp()
        {
            _currentLevel.SetText(_presenter.CurrentLevel);
            _requiredExperience.SetText(_presenter.RequiredExperience);
            _levelUpButton.interactable = _presenter.IsLevelUpButtonInteractable;
        }

        private void OnExperienceChanged(string experience)
        {
            _currentExperience.SetText(experience);
            _levelUpButton.interactable = _presenter.IsLevelUpButtonInteractable;
        }

        private void OnLevelUpButtonClicked()
        {
            _presenter.OnLevelUpButtonClicked();
        }
    }
}