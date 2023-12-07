using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [field: SerializeField] public UserInfo UserInfo { get; private set; } = new();
        [field: SerializeField] public CharacterLevel CharacterLevel { get; private set; } = new();
        [field: SerializeField] public CharacterInfo CharacterInfo { get; private set; } = new();
    }
}