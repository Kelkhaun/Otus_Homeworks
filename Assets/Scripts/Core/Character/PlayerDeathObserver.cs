using System;
using Core.Components;
using Infrastructure.GameSystem;
using UnityEngine;

namespace Core.Character
{
    [Serializable]
    public sealed class PlayerDeathObserver : IGameStartListener, IGameFinishListener
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