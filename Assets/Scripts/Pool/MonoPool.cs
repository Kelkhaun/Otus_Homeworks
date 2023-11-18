using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pool
{
    public sealed class MonoPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _container;
        private readonly Queue<T> _pool;

        public MonoPool(T prefab, int size, Transform container)
        {
            _prefab = prefab;
            _container = container;
            _pool = new Queue<T>(size);

            for (var i = 0; i < size; i++)
            {
                _pool.Enqueue(CreateObject());
            }
        }

        public T Get()
        {
            if (_pool.TryDequeue(out T obj))
            {
                return obj;
            }

            return CreateObject();
        }

        private T CreateObject()
        {
            return Object.Instantiate(_prefab, _container);
        }

        public void Release(T item)
        {
            _pool.Enqueue(item);
        }
    }
}