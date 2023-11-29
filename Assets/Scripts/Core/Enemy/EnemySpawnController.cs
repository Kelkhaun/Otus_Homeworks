using System;
using Infrastructure.DI;
using Infrastructure.GameSystem;

namespace Core.Enemy
{
    [Serializable]
    public sealed class EnemySpawnController : IGameStartListener, IGameFinishListener, IGameUpdateListener
    {
        private EnemyManager _enemyManager;
        private int _timeBetweenSpawn = 1;
        private float _elapsedTime;
        private bool _canSpawn = true;

        [Inject]
        public void Construct(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public void OnStartGame()
        {
            _canSpawn = true;
        }

        public void OnFinishGame()
        {
            _canSpawn = false;
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_canSpawn)
            {
                return;
            }
            
            _elapsedTime += deltaTime;

            if (_elapsedTime > _timeBetweenSpawn)
            {
                _enemyManager.Spawn();
                _elapsedTime = 0;
            }
        }
    }
}