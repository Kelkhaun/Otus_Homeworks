using Infrastructure;
using Infrastructure.GameSystem.Attributes;
using Infrastructure.Locator;
using UnityEngine;

namespace MVA_Lesson.Scripts
{
    public class EffectInstaller : GameInstaller
    {
        [SerializeField] private EffectView _effectViewPrefab;
        [SerializeField] private Transform _container;

        [Service(typeof(EffectCollection)), Listener]
        private EffectCollection _effectCollection = new();

        [Service(typeof(EffectCollectionObserver)), Listener]
        private EffectCollectionObserver _effectCollectionObserver = new();

        [Service(typeof(EffectPresenterFactory))]
        private EffectPresenterFactory _effectPresenterFactory = new();

        [SerializeField] private EffectTester _effectTester;

        public override void Inject(ServiceLocator serviceLocator)
        {
            _effectTester.Construct(_effectCollection);
            _effectPresenterFactory.Construct(_effectViewPrefab, _container);
            _effectCollectionObserver.Construct(_effectCollection, _effectPresenterFactory);
        }
    }
}