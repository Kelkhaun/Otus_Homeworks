using System;
using System.Collections.Generic;
using Infrastructure.GameSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Pool
{
    [Serializable]
    public abstract class MonoPool<T> : IGameStartListener where T : MonoBehaviour
    {
        [SerializeField] protected T Prefab;
        [SerializeField] protected int Size;
        [SerializeField] protected Transform Container;
        [SerializeField] protected Transform WorldTransform;

        protected readonly Queue<T> Pool = new();
        protected readonly HashSet<T> ActiveObject = new();

        public void OnStartGame()
        {
            for (var i = 0; i < Size; i++)
            {
                Pool.Enqueue(CreateObject());
            }
        }
        
        public virtual T Get()
        {
            if (Pool.TryDequeue(out T gameObject))
            {
                return gameObject;
            }

            return CreateObject();
        }

        public virtual void Release(T gameObject)
        {
            Pool.Enqueue(gameObject);
        }

        protected virtual T CreateObject()
        {
            return Object.Instantiate(Prefab, Container);
        }
    }
}