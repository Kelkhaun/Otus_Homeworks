using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
   public abstract class GameButton : MonoBehaviour
   {
      [SerializeField] private Button _button;

      private void OnEnable()
      {
         _button.onClick.AddListener(OnButtonClicked);
      }

      private void OnDisable()
      {
         _button.onClick.RemoveListener(OnButtonClicked);
      }

      protected abstract void OnButtonClicked();
   }
}