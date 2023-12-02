using System.Collections.Generic;
using Infrastructure.DI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MVA_Lesson.Scripts
{
    public sealed class EffectPresenterFactory
    {
        private EffectView _effectViewPrefab;
        private Transform _container;

        [Inject]
        public void Construct(EffectView effectView, Transform container)
        {
            _effectViewPrefab = effectView;
            _container = container;
        }

        public EffectPresenter CreatePresenter(Effect effect)
        {
            var view = Object.Instantiate(_effectViewPrefab, _container);
            var model = new Effect(effect.Value, effect.Icon, effect.Color);
            return new EffectPresenter(model, view);
        }
    }
}