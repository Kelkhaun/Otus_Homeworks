using System;
using UnityEngine;
using UpgradePopup.UpgradePopups;
using Object = UnityEngine.Object;

namespace UpgradePopup.Factory
{
    [Serializable]
    public sealed class CharacterStatViewFactory
    {
        [SerializeField] private StatPopupView _statPopupViewPrefab;
        [SerializeField] private Transform _container;

        public StatPopupView Create()
        {
            var statPopupView = Object.Instantiate(_statPopupViewPrefab, _container);
            statPopupView.gameObject.SetActive(false);
            return statPopupView;
        }
    }
}