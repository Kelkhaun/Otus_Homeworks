using System;
using UnityEngine;

namespace UpgradePopup.Presenter
{
    public interface IUpgradePresenter
    {
        string Name { get; }
        string Description { get; }
        Sprite ProfileIcon { get; }
        string CurrentLevel { get; }
        string CurrentExperience { get; }
        string RequiredExperience { get; }
        bool IsLevelUpButtonInteractable { get; }

        event Action<string> OnNameChanged;
        event Action<string> OnDescriptionChanged;
        event Action<Sprite> OnIconChanged;
        event Action OnLevelUp;
        event Action<string> OnExperienceChanged;

        void Enable();
        void Disable();
        void OnLevelUpButtonClicked();
    }
}