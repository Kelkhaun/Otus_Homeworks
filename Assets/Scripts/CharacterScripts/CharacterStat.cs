using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CharacterScripts
{
    [Serializable]
    public sealed class CharacterStat
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public int Value { get; private set; }
        
        public event Action<int, CharacterStat> OnValueChanged; 

        [Button]
        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value, this);
        }
    }
}