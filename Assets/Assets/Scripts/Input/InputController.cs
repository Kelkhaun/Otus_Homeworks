using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private KeyboardInput keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
        [FormerlySerializedAs("playerController")] [FormerlySerializedAs("_characterController")] [SerializeField] private PlayerShooter playerShooter;

        private void OnEnable()
        {
            keyboardInput.Move += _moveComponent.OnMove;
            keyboardInput.Fire += playerShooter.OnFire;
        }

        private void OnDisable()
        {
            keyboardInput.Move -= _moveComponent.OnMove;
            keyboardInput.Fire -= playerShooter.OnFire;
        }
    }
}