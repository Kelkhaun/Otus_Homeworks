using UnityEngine;

namespace ShootEmUp
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private KeyboardInput keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private CharacterController _characterController;

        private void OnEnable()
        {
            keyboardInput.Move += _moveComponent.MoveByRigidbodyVelocity;
            keyboardInput.Fire += _characterController.OnFire;
        }

        private void OnDisable()
        {
            keyboardInput.Move -= _moveComponent.MoveByRigidbodyVelocity;
            keyboardInput.Fire -= _characterController.OnFire;
        }
    }
}