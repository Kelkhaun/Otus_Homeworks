using Infrastructure.DI;
using Infrastructure.GameSystem;

namespace MVA_Lesson.Scripts
{
    public sealed class EffectCollectionObserver : IGameStartListener, IGameFinishListener
    {
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
                _effectPresenterFactory.CreatePresenter(effect);
            }
        }

        private void OnEffectAdded(Effect effect)
        {
            if (_effectPresenterFactory.TryGetPresenter(effect, out var presenter))
            {
                presenter.UpdateValue(effect.Value);
            }
            else
            {
                _effectPresenterFactory.CreatePresenter(effect);
            }
        }

        private void OnEffectRemoved(Effect effect)
        {
            _effectPresenterFactory.Remove(effect);
        }
    }
}