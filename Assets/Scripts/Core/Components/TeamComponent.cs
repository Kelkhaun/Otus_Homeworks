using UnityEngine;

namespace Core.Components
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [field: SerializeField] public bool IsPlayer { get; private set; }
    }
}