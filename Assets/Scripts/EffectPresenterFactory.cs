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

        private Dictionary<Effect, EffectPresenter> _effectPresenters = new();

        [Inject]
        public void Construct(EffectView effectView, Transform container)
        {
            _effectViewPrefab = effectView;
            _container = container;
        }
        
        public bool TryGetPresenter(Effect effect, out EffectPresenter presenter)
        {
            return _effectPresenters.TryGetValue(effect, out presenter);
        }

        public void CreatePresenter(Effect effect)
        {
            var view = Object.Instantiate(_effectViewPrefab, _container);
            var model = new Effect(effect.Value, effect.Icon, effect.Color);
            var effectPresenter = new EffectPresenter(model, view);
            _effectPresenters.Add(effect, effectPresenter);
        }
        
        public void Remove(Effect effect)
        {
            if (_effectPresenters.TryGetValue(effect, out var effectPresenter))
            {
                _effectPresenters.Remove(effect);
                effectPresenter.Dispose();
            }
        }
    }
}