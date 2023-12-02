using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.GameSystem;

namespace MVA_Lesson.Scripts
{
    public sealed class EffectCollectionObserver : IGameStartListener, IGameFinishListener
    {
        private Dictionary<Effect, EffectPresenter> _effectPresenters = new();
        private EffectPresenterFactory _effectPresenterFactory;
        private EffectCollection _effectCollection;

        [Inject]
        public void Construct(EffectCollection effectCollection, EffectPresenterFactory effectPresenterFactory)
        {
            _effectPresenterFactory = effectPresenterFactory;
            _effectCollection = effectCollection;
        }

        public void OnStartGame()
        {
            _effectCollection.OnAdded += OnEffectAdded;
            _effectCollection.OnRemoved += OnEffectRemoved;
            CreatePresenters();
        }

        public void OnFinishGame()
        {
            _effectCollection.OnAdded -= OnEffectAdded;
            _effectCollection.OnRemoved -= OnEffectRemoved;
        }

        private void CreatePresenters()
        {
            foreach (var effect in _effectCollection.GetEffects())
            {
                EffectPresenter presenter = _effectPresenterFactory.CreatePresenter(effect);
                _effectPresenters.Add(effect, presenter);
            }
        }

        private void OnEffectAdded(Effect effect)
        {
            if (_effectPresenters.TryGetValue(effect, out EffectPresenter presenter))
            {
                presenter.UpdateValue(effect.Value);
            }
            else
            {
                var effectPresenter = _effectPresenterFactory.CreatePresenter(effect);
                _effectPresenters.Add(effect, effectPresenter);
            }
        }

        private void OnEffectRemoved(Effect effect)
        {
            if (_effectPresenters.TryGetValue(effect, out EffectPresenter presenter))
            {
                presenter.Dispose();
                _effectPresenters.Remove(effect);
            }
        }
    }
}