using Assets.Scripts.Components;
using Assets.Scripts.GameManagers;
using UnityEngine;

namespace Assets.Scripts.Character
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