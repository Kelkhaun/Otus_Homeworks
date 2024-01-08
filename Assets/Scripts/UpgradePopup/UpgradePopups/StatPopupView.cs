using CharacterScripts;
using TMPro;
using UnityEngine;

namespace UpgradePopup.UpgradePopups
{
    public sealed class StatPopupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statText;

        public CharacterStat CharacterStat { get; private set; }

        public void Setup(string text, CharacterStat characterStat)
        {
            CharacterStat = characterStat;
            _statText.SetText(text);
        }
    }
}