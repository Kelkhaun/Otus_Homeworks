using Core.Components;
using Infrastructure;
using UnityEngine;

namespace Core.Character
{
    public sealed class PlayerDeathObserver : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent _playerHitPointsComponent;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _playerHitPointsComponent.OnEnemyDying += OnPlayerDeath;
        }

        private void OnDisable()
        {
            _playerHitPointsComponent.OnEnemyDying -= OnPlayerDeath;
        }

        private void OnPlayerDeath(GameObject _) => _gameManager.FinishGame();
    }
}