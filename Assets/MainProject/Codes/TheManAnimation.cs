using UnityEngine;

namespace Aftab
{
    public class TheManAnimation : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField]
        private Animator animator;

        private string idle1StateName = "Idle";
        private int idleStateHash = 1;
        private string runningStateName = "Running";
        private int runningStateHash = 2;

        GameStateManager gameStateManager;

        private void Start()
        {
            SetAnimationHashNames();
            PlayAnimation(idleStateHash);
            gameStateManager = GameStateManager.Instance;
            gameStateManager.OnGameStateChanged += OnGameStateChange;
        }

        private void OnDisable()
        {
            gameStateManager.OnGameStateChanged -= OnGameStateChange;
        }

        private void SetAnimationHashNames()
        {
            idleStateHash = Animator.StringToHash(idle1StateName);
            runningStateHash = Animator.StringToHash(runningStateName);
        }

        private void PlayAnimation(int stateHash, float normalizedTransitionDuration = 0.0f, int layer = 0)
        {
            animator.CrossFade(stateHash, normalizedTransitionDuration, layer);
        }

        private void OnGameStateChange(GameStates gameState)
        {
            switch (gameState)
            {
                case GameStates.Initial:
                    PlayAnimation(idleStateHash);
                    break;
                case GameStates.Playing:
                    PlayAnimation(runningStateHash);
                    break;
                case GameStates.Paused:
                    PlayAnimation(idleStateHash);
                    break;
                default:
                    PlayAnimation(idleStateHash);
                    break;
            }
        }
    }
}
