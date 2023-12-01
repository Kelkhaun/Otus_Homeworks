using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MVA_Lesson.Scripts
{
    public class EffectTester : MonoBehaviour
    {
        [SerializeField] private List<EffectConfig> _effectConfigs = new();

        private EffectCollection _effectCollection;
        private HashSet<Effect> _effects = new();
        private Dictionary<Effect, EffectConfig> _configs = new();
        private Queue<EffectConfig> _configsQueue = new();

        private void Awake()
        {
            _configsQueue = new Queue<EffectConfig>(_effectConfigs);
        }

        public void Construct(EffectCollection effectCollection)
        {
            _effectCollection = effectCollection;
        }

        [Button]
        public void AddEffect()
        {
            if (_configsQueue.TryDequeue(out var config))
            {
                var effect = new Effect(config.Value, config.Icon, config.Color);
                _effects.Add(effect);
                _effectCollection.AddEffect(effect);
                _configs.Add(effect, config);
            }
        }

        [Button]
        public void AddExistetEffect()
        {
            int effectIndex = Random.Range(0, _effects.Count);
            var effect = _effects.ToArray()[effectIndex];
            _effectCollection.AddEffect(effect);
        }

        [Button]
        public void DeleteRandomEffect()
        {
            int effectIndex = Random.Range(0, _effects.Count);
            var effect = _effects.ToArray()[effectIndex];
            _effectCollection.RemoveEffect(effect);
            _effects.Remove(effect);
            _configsQueue.Enqueue(_configs[effect]);
        }
    }

    [Serializable]
    public struct EffectConfig
    {
        [field: SerializeField] public float Value { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public Color Color { get; private set; }
    }
}