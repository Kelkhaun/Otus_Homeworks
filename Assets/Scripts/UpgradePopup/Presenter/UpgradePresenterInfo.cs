using System;
using CharacterScripts;
using UnityEngine;

namespace UpgradePopup.Presenter
{
    public class UpgradePresenterInfo : IUpgradeInfoPresenter
    {
        private Character _character;

        public string Name => _character.UserInfo.Name;
        public string Description => _character.UserInfo.Description;
        public Sprite ProfileIcon => _character.UserInfo.Icon;

        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;

        public UpgradePresenterInfo(Character character)
        {
            _character = character;
        }

        public void Enable()
        {
            _character.UserInfo.OnNameChanged += NameChanged;
            _character.UserInfo.OnDescriptionChanged += DescriptionChanged;
            _character.UserInfo.OnIconChanged += IconChanged;       
        }

        public void Disable()
        {
            _character.UserInfo.OnNameChanged -= NameChanged;
            _character.UserInfo.OnDescriptionChanged -= DescriptionChanged;
            _character.UserInfo.OnIconChanged -= IconChanged;
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
    }
}