using UnityEngine;

namespace Core.Input
{
    [CreateAssetMenu(fileName = "KeyboardMap", menuName = "Input/KeyboardMap")]
    public sealed class KeyboardMap : ScriptableObject
    {
        [field: SerializeField] public KeyCode ShootKey = KeyCode.Space;
        [field: SerializeField] public KeyCode LeftKey = KeyCode.LeftArrow;
        [field: SerializeField] public KeyCode RightKey = KeyCode.RightArrow;
    }
}