using Infrastructure;
using UnityEngine;

namespace Ui
{
    public sealed class StartGameButton : GameButton, IGameStartListener
    {
        [SerializeField] private DelayedGameStarter _delayedGameStarter;
        
        protected override void OnButtonClicked()
        {
            _delayedGameStarter.StartGame();
            gameObject.SetActive(false);
        }

        public void OnStartGame()
        {
            gameObject.SetActive(false);
        }
    }
}