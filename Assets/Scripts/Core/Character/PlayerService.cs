using System;
using Core.Bullets;
using UnityEngine;

namespace Core.Character
{
    [Serializable]
    public sealed class PlayerService
    {
      [field: SerializeField] public GameObject Player { get; private set; }
      [field: SerializeField] public BulletConfig BulletConfig { get; set; }
    }
}