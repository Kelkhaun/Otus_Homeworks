using System;
using Character;
using UnityEngine;
using UpgradePopup.Pool;

namespace UpgradePopup.Presenter
{
    public sealed class CharacterUpgradePresenter : IUpgradePresenter
    {
        private Character.Character _character;
        private CharacterStatPool _characterStatPool;

        public string Name => _character.UserInfo.Name;
        public string Description => _character.UserInfo.Description;
        public Sprite ProfileIcon => _character.UserInfo.Icon;

        public string CurrentLevel => "Level: " + _character.CharacterLevel.CurrentLevel.ToString();
        public string CurrentExperience => _character.CharacterLevel.CurrentExperience.ToString() + " / ";
        public string RequiredExperience => _character.CharacterLevel.RequiredExperience.ToString();
        public bool IsLevelUpButtonInteractable => _character.CharacterLevel.CanLevelUp();

        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;
        public event Action OnLevelUp;
        public event Action<string> OnExperienceChanged;

        public CharacterUpgradePresenter(Character.Character character, CharacterStatPool characterStatPool)
        {
            _characterStatPool = characterStatPool;
            _character = character;
        }

        public void Enable()
        {
            _character.UserInfo.OnNameChanged += NameChanged;
            _character.UserInfo.OnDescriptionChanged += DescriptionChanged;
            _character.UserInfo.OnIconChanged += IconChanged;
            _character.CharacterLevel.OnLevelUp += LevelUp;
            _character.CharacterLevel.OnExperienceChanged += ExperienceChanged;
            _character.CharacterInfo.OnStatAdded += OnStatAdded;
            _character.CharacterInfo.OnStatRemoved += OnStatRemoved;
        }

        public void Disable()
        {
            _character.UserInfo.OnNameChanged -= NameChanged;
            _character.UserInfo.OnDescriptionChanged -= DescriptionChanged;
            _character.UserInfo.OnIconChanged -= IconChanged;
            _character.CharacterLevel.OnLevelUp -= LevelUp;
            _character.CharacterLevel.OnExperienceChanged -= ExperienceChanged;
            _character.CharacterInfo.OnStatAdded -= OnStatAdded;
            _character.CharacterInfo.OnStatRemoved -= OnStatRemoved;

            var stats = _character.CharacterInfo.GetStats();

            foreach (var stat in stats)
            {
                stat.OnValueChanged -= OnValueChanged;
            }
        }

        private void OnStatAdded(CharacterStat characterStat)
        {
            characterStat.OnValueChanged += OnValueChanged;
            var statPopupView = _characterStatPool.Get();
            statPopupView.Setup(characterStat.Name + ": " + characterStat.Value.ToString(), characterStat);
        }

        private void OnValueChanged(int value, CharacterStat characterStat)
        {
            var view = _characterStatPool.FindView(characterStat);
            view.Setup(characterStat.Name + ": " + characterStat.Value.ToString(), characterStat);
        }

        private void OnStatRemoved(CharacterStat characterStat)
        {
            _characterStatPool.Release(characterStat);
        }

        public void ExperienceChanged(int experience)
        {
            OnExperienceChanged?.Invoke(experience.ToString() + " /");
        }

        public void LevelUp()
        {
            OnLevelUp?.Invoke();
        }

        public void NameChanged(string name)
        {
            OnNameChanged?.Invoke(name);
        }

        public void DescriptionChanged(string description)
        {
            OnDescriptionChanged?.Invoke(description);
        }

        public void IconChanged(Sprite icon)
        {
            OnIconChanged?.Invoke(icon);
        }

        public void OnLevelUpButtonClicked()
        {
            _character.CharacterLevel.LevelUp();
        }
    }
}