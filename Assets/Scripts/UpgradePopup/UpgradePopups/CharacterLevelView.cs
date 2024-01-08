using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UpgradePopup.Presenter;

namespace UpgradePopup.UpgradePopups
{
    public sealed class CharacterLevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevel;
        [SerializeField] private TMP_Text _currentExperience;
        [SerializeField] private TMP_Text _requiredExperience;
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Image _slider;

        private IUpgradeLevelInfoPresenter _presenter;

        public void Show(object args)
        {
            if (args is not IUpgradeLevelInfoPresenter presenter)
            {
                throw new Exception("Expected Product Presenter");
            }

            _presenter = presenter;
            gameObject.SetActive(true);

            _slider.fillAmount = _presenter.SliderFillAmount;
            _currentLevel.SetText(_presenter.CurrentLevel);
            _currentExperience.SetText(_presenter.CurrentExperience);
            _requiredExperience.SetText(_presenter.RequiredExperience);
            _levelUpButton.interactable = _presenter.IsLevelUpButtonInteractable;
            presenter.OnExperienceChanged += OnExperienceChanged;
            presenter.OnLevelUp += OnLevelUp;
            _levelUpButton.onClick.AddListener(OnLevelUpButtonClicked);
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
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
            _slider.fillAmount = _presenter.SliderFillAmount;
        }

        private void OnExperienceChanged(string experience)
        {
            _currentExperience.SetText(experience);
            _levelUpButton.interactable = _presenter.IsLevelUpButtonInteractable;
            var amount = _presenter.SliderFillAmount;
            _slider.fillAmount = amount;
        }

        private void OnLevelUpButtonClicked()
        {
            _presenter.OnLevelUpButtonClicked();
        }
    }
}