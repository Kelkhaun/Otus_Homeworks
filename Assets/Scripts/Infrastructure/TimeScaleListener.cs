using UnityEngine;

namespace Infrastructure
{
    public class TimeScaleListener : MonoBehaviour, IGamePauseListener, IGameResumeListener
    {
        public void OnResumeGame()
        {
            Time.timeScale = 1;
        }

        public void OnPauseGame()
        {
            Time.timeScale = 0;
        }
    }
}
