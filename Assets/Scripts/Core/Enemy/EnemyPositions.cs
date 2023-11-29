using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    [Serializable]
    public sealed class EnemyPositions
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(_spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(_attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            int index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}