using Infrastructure;
using Infrastructure.GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public sealed class StartGameButton : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private GameLauncher gameLauncher;
        [SerializeField] private Button _button;

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
            gameLauncher.StartGame();
            gameObject.SetActive(false);
        }
    }
}