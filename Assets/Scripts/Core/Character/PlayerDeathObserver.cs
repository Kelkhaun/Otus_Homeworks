using Core.Components;
using Infrastructure;
using UnityEngine;

namespace Core.Character
{
    public sealed class PlayerDeathObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private HitPointsComponent _playerHitPointsComponent;
        [SerializeField] private GameManager _gameManager;

        public void OnStartGame()
        {
            _playerHitPointsComponent.OnEnemyDying += OnPlayerDeath;
        }

        public void OnFinishGame()
        {
            _playerHitPointsComponent.OnEnemyDying -= OnPlayerDeath;
        }

        private void OnPlayerDeath(GameObject _) => _gameManager.FinishGame();
    }
}