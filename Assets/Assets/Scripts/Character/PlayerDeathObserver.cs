using ShootEmUp;
using UnityEngine;

public class PlayerDeathObserver : MonoBehaviour
{
    [SerializeField] private HitPointsComponent _playerHitPointsComponent;
    [SerializeField] private GameManager _gameManager;
    
    private void OnEnable()
    {
        _playerHitPointsComponent.HpEmpty += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _playerHitPointsComponent.HpEmpty -= OnPlayerDeath;
    }

    private void OnPlayerDeath(GameObject _) => _gameManager.FinishGame();
}