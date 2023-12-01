using System;
using System.Collections.Generic;

namespace MVA_Lesson.Scripts
{
    public sealed class EffectCollection
    {
        public event Action<Effect> OnAdded;
        public event Action<Effect> OnRemoved;

        private readonly HashSet<Effect> _effects = new();

        public void AddEffect(Effect effect)
        {
            _effects.Add(effect);
            OnAdded?.Invoke(effect);
        }

        public void RemoveEffect(Effect effect)
        {
            if (_effects.Remove(effect))
            {
                OnRemoved?.Invoke(effect);
            }
        }

        public IEnumerable<Effect> GetEffects()
        {
            return _effects;
        }
    }
}