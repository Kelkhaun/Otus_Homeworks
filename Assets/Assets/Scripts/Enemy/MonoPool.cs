using System.Collections.Generic;
using UnityEngine;

public sealed class MonoPool<T> where T : MonoBehaviour
{
    private readonly T _prefab;
    private readonly Queue<T> _pool;
    private bool _isAutoExpand;

    public MonoPool(T prefab, int size, bool isAutoExpand = false)
    {
        _prefab = prefab;
        _pool = new Queue<T>(size);
        _isAutoExpand = isAutoExpand;

        for (var i = 0; i < size; i++)
        {
            CreateObject();
            _pool.Enqueue(Object.Instantiate(_prefab));
        }
    }

    public T Get()
    {
        if (_pool.TryDequeue(out T obj))
        {
            return obj;
        }

        return _isAutoExpand ? CreateObject() : null;
    }

    private T CreateObject()
    {
        return Object.Instantiate(_prefab);
    }

    public void Release(T item)
    {
        _pool.Enqueue(item);
    }
}