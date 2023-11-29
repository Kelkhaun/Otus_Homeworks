using Infrastructure;
using Infrastructure.GameSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public sealed class PauseButton : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private string _resume = "Продолжить";
        private string _pause = "Пауза";
        
        public void OnStartGame()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void OnFinishGame()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
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