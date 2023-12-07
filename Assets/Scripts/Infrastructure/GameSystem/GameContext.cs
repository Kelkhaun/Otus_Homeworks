﻿using Scripts.Infrastructure.DI;
using Scripts.Infrastructure.GameSystem.Attributes;
using Scripts.Infrastructure.Locator;
using UnityEngine;

namespace Scripts.Infrastructure.GameSystem
{
    public sealed class GameContext : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private ServiceLocator _serviceLocator;
        [SerializeField] private bool _isInjectGameObjectsOnScene;
        [SerializeField] private MonoBehaviour[] _modules;

        private void Awake()
        {
            foreach (var module in _modules)
            {
                if (module is IGameListenerProvider listenerProvider)
                {
                    _gameManager.AddListeners(listenerProvider.ProvideListeners());
                }

                if (module is IServiceProvider serviceProvider)
                {
                    var services = serviceProvider.ProvideServices();

                    foreach (var (type, service) in services)
                    {
                        _serviceLocator.BindService(type, service);
                    }
                }
            }
        }

        private void Start()
        {
            foreach (var module in _modules)
            {
                if (module is IInjectProvider injectProvider)
                {
                    injectProvider.Inject(_serviceLocator);
                }
            }

            if (_isInjectGameObjectsOnScene)
                InjectGameObjectsOnScene();
        }

        private void InjectGameObjectsOnScene()
        {
            GameObject[] rootGameObjects = gameObject.scene.GetRootGameObjects();

            foreach (var go in rootGameObjects)
            {
                Inject(go.transform);
            }
        }

        private void Inject(Transform targetTransform)
        {
            MonoBehaviour[] targets = targetTransform.GetComponents<MonoBehaviour>();

            foreach (var target in targets)
            {
                DependencyInjector.Inject(target, _serviceLocator);
            }

            foreach (Transform child in targetTransform)
            {
                Inject(child);
            }
        }
    }
}