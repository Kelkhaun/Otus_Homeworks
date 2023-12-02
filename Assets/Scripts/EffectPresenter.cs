using UnityEngine;

namespace MVA_Lesson.Scripts
{
    public sealed class EffectPresenter 
    {
        private readonly EffectView _view;
        private readonly Effect _effect;
        
        public EffectPresenter(Effect effect, EffectView view)
        {
            _effect = effect;
            _view = view;
            Init();
        }

        public void UpdateValue(float value)
        {
            var targetValue = _effect.Value + value;
            _effect.SetValue(targetValue);
        }
        
        public void Dispose()
        {
            _effect.OnValueChanged -= SetViewText;
            Object.Destroy(_view.gameObject);
        }

        private void SetViewText(float text)
        {
            _view.SetText(_effect.Value.ToString());
        }

        private void Init()
        {
            _view.SetText(_effect.Value.ToString());
            _view.SetIcon(_effect.Icon);
            _view.SetLabelColor(_effect.Color);
            _effect.OnValueChanged += SetViewText;
        }
    }
}