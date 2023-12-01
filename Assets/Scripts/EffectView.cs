using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVA_Lesson.Scripts
{
    public sealed class EffectView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _label;

        public void SetText(string text)
        {
            _text.SetText(text);
        }

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        public void SetLabelColor(Color color)
        {
            _label.color = color;
        }
    }
}