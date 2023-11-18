using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infrastructure
{
    public sealed class DelayedGameStarter : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private float _delay;
        [SerializeField] private float _countdown;

        private float _startDelay;
        
        private void Awake()
        {
            _startDelay = _delay;
        }

        public void StartGame()
        {
            StartCoroutine(StartGameRoutine());
        }

        private IEnumerator StartGameRoutine()
        {
            while (_delay > 0)
            {
                print($"Старт через {_delay} секунды.");
                _delay--;
                yield return new WaitForSeconds(_countdown);
            }

            _gameManager.StartGame();
        }
    }
}