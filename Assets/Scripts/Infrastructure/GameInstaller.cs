using System.Collections.Generic;
using Infrastructure.Installers;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Infrastructure
{
    [RequireComponent(typeof(GameManager))]
    public sealed class GameInstaller : SerializedMonoBehaviour
    {
        [OdinSerialize] List<IInstaller> _listeners = new();

        private void Awake()
        {
            var gameManager = GetComponent<GameManager>();

            for (int i = 0; i < _listeners.Count; i++)
            {
                List<IGameListener> gameListener = _listeners[i].Install();

                foreach (var listener in gameListener)
                {
                    gameManager.AddListener(listener);
                }
            }
        }
    }
}