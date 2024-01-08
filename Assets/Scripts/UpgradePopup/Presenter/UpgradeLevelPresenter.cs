using System;
using CharacterScripts;

namespace UpgradePopup.Presenter
{
    public class UpgradeLevelPresenter : IUpgradeLevelInfoPresenter
    {
        private Character _character;

        public string CurrentLevel => "Level: " + _character.CharacterLevel.CurrentLevel.ToString();
        public string CurrentExperience => _character.CharacterLevel.CurrentExperience.ToString() + " / ";
        public string RequiredExperience => _character.CharacterLevel.RequiredExperience.ToString();
        public bool IsLevelUpButtonInteractable => _character.CharacterLevel.CanLevelUp();
        public float SliderFillAmount =>  (float)_character.CharacterLevel.CurrentExperience / _character.CharacterLevel.RequiredExperience;

        public event Action OnLevelUp;
        public event Action<string> OnExperienceChanged;

        public UpgradeLevelPresenter(Character character)
        {
            _character = character;
        }

        public void Enable()
        {
            _character.CharacterLevel.OnLevelUp += LevelUp;
            _character.CharacterLevel.OnExperienceChanged += ExperienceChanged;
        }

        public void Disable()
        {
            _character.CharacterLevel.OnLevelUp -= LevelUp;
            _character.CharacterLevel.OnExperienceChanged -= ExperienceChanged;
        }

        public void ExperienceChanged(int experience)
        {
            OnExperienceChanged?.Invoke(experience.ToString() + " /");
        }

        public void LevelUp()
        {
            OnLevelUp?.Invoke();
        }

        public void OnLevelUpButtonClicked()
        {
            _character.CharacterLevel.LevelUp();
        }
    }
}