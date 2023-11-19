using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
   public abstract class GameButton : MonoBehaviour, IGameStartListener, IGameFinishListener
   {
      [SerializeField] private Button _button;

      public void OnStartGame()
      {
         _button.onClick.AddListener(OnButtonClicked);
      }

      public void OnFinishGame()
      {
         _button.onClick.RemoveListener(OnButtonClicked);
      }

      protected abstract void OnButtonClicked();
   }
}