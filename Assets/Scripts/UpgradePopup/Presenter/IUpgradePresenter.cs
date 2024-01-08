using System;
using UnityEngine;

namespace UpgradePopup.Presenter
{
    public interface IUpgradePresenter
    {
        IUpgradeInfoPresenter PlayerInfoPresenter { get; }
        IUpgradeLevelInfoPresenter LevelInfoPresenter { get; }

        void Enable();
        void Disable();
    }

    public interface IUpgradeLevelInfoPresenter
    {
        string CurrentLevel { get; }
        string CurrentExperience { get; }
        string RequiredExperience { get; }
        bool IsLevelUpButtonInteractable { get; }
        float SliderFillAmount { get; }

        event Action OnLevelUp;
        event Action<string> OnExperienceChanged;
        void OnLevelUpButtonClicked();
        void Enable();
        void Disable();
    }

    public interface IUpgradeInfoPresenter 
    {
        string Name { get; }
        string Description { get; }
        Sprite ProfileIcon { get; }
        event Action<string> OnNameChanged;
        event Action<string> OnDescriptionChanged;
        event Action<Sprite> OnIconChanged;

        void Enable();
        void Disable();
    }
}