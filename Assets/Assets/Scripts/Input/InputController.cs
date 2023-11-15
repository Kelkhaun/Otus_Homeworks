using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private MoveComponent _moveComponent;
         [FormerlySerializedAs("fireListener")] [SerializeField] private PlayerFireListener playerFireListener;

        private void OnEnable()
        {
            _keyboardInput.Move += _moveComponent.OnMove;
            _keyboardInput.Fire += playerFireListener.OnFire;
        }

        private void OnDisable()
        {
            _keyboardInput.Move -= _moveComponent.OnMove;
            _keyboardInput.Fire -= playerFireListener.OnFire;
        }
    }
}