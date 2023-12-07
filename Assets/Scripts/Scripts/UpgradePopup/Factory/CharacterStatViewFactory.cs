using System;
using Scripts.UpgradePopup.UpgradePopups;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.UpgradePopup.Factory
{
    [Serializable]
    public class CharacterStatViewFactory
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