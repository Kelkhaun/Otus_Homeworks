using System;
using Infrastructure;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Ui
{
    [Serializable]
    public sealed class StartGameButtonModel : IGameStartListener, IGameFinishListener
    {
        [SerializeField] private ButtonView _startButtonView;
        [SerializeField] private GameLauncher gameLauncher;

        public void OnStartGame()
        {
            _startButtonView.Button.onClick.AddListener(OnButtonClicked);
        }

        public void OnFinishGame()
        {
            _startButtonView.Button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            gameLauncher.StartGame();
            _startButtonView.gameObject.SetActive(false);
        }
    }
}