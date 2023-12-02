using System;
using UnityEngine;

namespace MVA_Lesson.Scripts
{
    public sealed class Effect
    {
        public float Value { get; private set; }
        public Sprite Icon { get;  }
        public Color Color { get; }

        public event Action<float> OnValueChanged;

        public Effect(float value, Sprite icon, Color color)
        {
            Value = value;
            Icon = icon;
            Color = color;
        }

        public void SetValue(float value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}