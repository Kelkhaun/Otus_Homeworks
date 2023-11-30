using System;
using Core.Components;
using Infrastructure.DI;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Character
{
    [Serializable]
    public sealed class PlayerDeathObserver : IGameStartListener, IGameFinishListener
    {
        private HitPointsComponent _playerHitPointsComponent;
        private GameManager _gameManager;
        
        [Inject]
        private void Construct(GameManager gameManager, PlayerService playerService)
        {
            _gameManager = gameManager;
            _playerHitPointsComponent = playerService.Player.GetComponent<HitPointsComponent>();
        }
        
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