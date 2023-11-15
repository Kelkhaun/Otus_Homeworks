using ShootEmUp;
using UnityEngine;

public class PlayerDeathObserver : MonoBehaviour
{
    [SerializeField] private HitPointsComponent _characterHitPointsComponent;
    [SerializeField] private GameManager _gameManager;
    
    private void OnEnable()
    {
        _characterHitPointsComponent.hpEmpty += OnCharacterDeath;
    }

    private void OnDisable()
    {
        _characterHitPointsComponent.hpEmpty -= OnCharacterDeath;
    }

    private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();
}