using System;
using UnityEngine;

namespace Aftab
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance { get; private set; }
        private GameStates currentGameStates = GameStates.Initial;
        public event Action<GameStates> OnGameStateChanged;

        private void Awake()
        {
            Instance = this;
        }

        public void SetGameState(GameStates state) //Start button-Playing, Settings-Pause, Cross-Playing
        {
            if (currentGameStates == state) return;
            currentGameStates = state;
            OnGameStateChanged?.Invoke(state);
        }
    }

    public enum GameStates
    {
        Initial = 0,
        Playing = 1,
        Paused = 2
    }
}
