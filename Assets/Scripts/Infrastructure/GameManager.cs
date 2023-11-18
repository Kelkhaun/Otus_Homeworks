using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Infrastructure
{
    public sealed class GameManager : SerializedMonoBehaviour
    {
        private readonly List<IGameListener> _listeners = new();

        [OdinSerialize][ReadOnly] public GameState State { get; private set; }
        
        public void AddListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            _listeners.Add(listener);
        }
        
        public void RemoveListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }

            _listeners.Remove(listener);
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            State = GameState.PLAYING;
        }
        
        [Button]
        public void PauseGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }

            State = GameState.PAUSED;
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }

            State = GameState.PLAYING;
        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }

            State = GameState.FINISHED;
        }
    }
}