using Character;
using TMPro;
using UnityEngine;

namespace UpgradePopup.UpgradePopups
{
    public class StatPopupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statText;

        public CharacterStat CharacterStat { get; private set; }

        public void Initialize(string text, CharacterStat characterStat)
        {
            CharacterStat = characterStat;
            _statText.SetText(text);
        }
    }
}