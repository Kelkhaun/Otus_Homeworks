using UnityEngine;

namespace Infrastructure
{
    public class TimeScaleListener : MonoBehaviour, IGamePauseListener, IGameResumeListener, IGameFinishListener, IGameStartListener
    {
        private int _maxTimeScale = 1;
        private int _minTimeScale = 0;

        public void OnResumeGame()
        {
            SetTimeScale(_maxTimeScale);
        }

        public void OnPauseGame()
        {
            SetTimeScale(_minTimeScale);
        }

        public void OnFinishGame()
        {
            SetTimeScale(_minTimeScale);
        }

        public void OnStartGame()
        {
            SetTimeScale(_maxTimeScale);
        }

        private void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}
