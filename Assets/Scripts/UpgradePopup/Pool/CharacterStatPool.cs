using System.Collections.Generic;
using Character;
using Infrastructure.DI;
using UpgradePopup.Factory;
using UpgradePopup.UpgradePopups;

namespace UpgradePopup.Pool
{
    public sealed class CharacterStatPool
    {
        private Queue<StatPopupView> _pool = new Queue<StatPopupView>();
        private CharacterStatViewFactory _characterStatViewFactory;
        private int _poolSize = 6;

        private List<StatPopupView> _cachedPopupViews = new();

        [Inject]
        private void Construct(CharacterStatViewFactory characterStatViewFactory)
        {
            _characterStatViewFactory = characterStatViewFactory;
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var view = _characterStatViewFactory.Create();
                _cachedPopupViews.Add(view);
                _pool.Enqueue(view);
            }
        }

        public StatPopupView Get()
        {
            if (_pool.TryDequeue(out var view))
            {
                view.gameObject.SetActive(true);
                return view;
            }
            else
            {
                var newView = _characterStatViewFactory.Create();
                newView.gameObject.SetActive(true);
                _cachedPopupViews.Add(view);
                return newView;
            }
        }

        public void Release(CharacterStat characterStat)
        {
            var view = FindView(characterStat);
            view.gameObject.SetActive(false);
            _pool.Enqueue(view);
        }

        public StatPopupView FindView(CharacterStat characterStat)
        {
            var view = _cachedPopupViews.Find(x => x.CharacterStat == characterStat);
            return view;
        }
    }
}