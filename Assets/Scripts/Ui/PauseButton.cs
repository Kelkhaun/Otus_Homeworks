using Infrastructure;
using TMPro;
using UnityEngine;

namespace Ui
{
    public sealed class PauseButton : GameButton
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private TMP_Text _text;

        private string _resume = "Продолжить";
        private string _pause = "Пауза";

        protected override void OnButtonClicked()
        {
            if (_gameManager.State == GameState.PAUSED)
            {
                _gameManager.ResumeGame();
                _text.SetText(_pause);
            }
            else if (_gameManager.State == GameState.PLAYING)
            {
                _gameManager.PauseGame();
                _text.SetText(_resume);
            }
        }
    }
}