using System.Collections.Generic;
using UnityEngine;

namespace Core.Pool
{
    public abstract class MonoPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [Header("Pool")] [SerializeField] protected T Prefab;
        [SerializeField] protected int Size;
        [SerializeField] protected Transform Container;
        [SerializeField] protected Transform WorldTransform;

        protected readonly Queue<T> Pool = new();
        protected readonly HashSet<T> ActiveObject = new();
        
        private void Awake()
        {
            for (var i = 0; i < Size; i++)
            {
                Pool.Enqueue(CreateObject());
            }

            Pool.Dequeue();

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

        private T CreateObject()
        {
            return Instantiate(Prefab, Container);
        }
    }
}