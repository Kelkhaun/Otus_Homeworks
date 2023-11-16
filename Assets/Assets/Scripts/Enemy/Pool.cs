using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour
{
    [Header("Pool")] [SerializeField] protected T Prefab;
    [SerializeField] protected int Size;
    [SerializeField] protected Transform Container;
    [SerializeField] protected Transform WorldTransform;

    protected readonly HashSet<T> ActiveObject = new();

    public abstract T Get();

    public abstract void Release(T obj);
}