using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public sealed class ButtonView : MonoBehaviour
    {
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public TMP_Text Text { get; private set; }
    }
}