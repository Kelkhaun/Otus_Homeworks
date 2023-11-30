using System;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Ui
{
    [Serializable]
    public sealed class PauseButton : IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private ButtonView _button;

        private string _resume = "Продолжить";
        private string _pause = "Пауза";
        
        public void OnStartGame()
        {
            _button.Button.onClick.AddListener(OnButtonClicked);
        }

        public void OnFinishGame()
        {
            _button.Button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            if (_gameManager.State == GameState.PAUSED)
            {
                _gameManager.ResumeGame();
                _button.Text.SetText(_pause);
            }
            else if (_gameManager.State == GameState.PLAYING)
            {
                _gameManager.PauseGame();
                _button.Text.SetText(_resume);
            }
        }
    }
}