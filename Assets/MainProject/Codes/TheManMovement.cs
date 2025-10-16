using System.Collections;
using UnityEngine;

namespace Aftab
{
    public class TheManMovement : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField]
        private Transform transformToMove;
        [SerializeField]
        private float movementSpeed = 5.0f;
        private Coroutine currentCR = null;

        private GameStateManager gameStateManager;

        private void Start()
        {
            gameStateManager = GameStateManager.Instance;
            gameStateManager.OnGameStateChanged += OnGameStateChange;
            transformToMove.position = CheckPoints.Instance.GetCurrentCheckPoint().position;
        }

        private void OnDisable()
        {
            gameStateManager.OnGameStateChanged -= OnGameStateChange;
        }

        private void ManageMovement(bool move)
        {
            CleanCurrentCR();
            if(move) currentCR = StartCoroutine(MovementCR());

            IEnumerator MovementCR()
            {
                yield return null;

                Transform currenCheckPoint = CheckPoints.Instance.GetCurrentCheckPoint();
                Transform nextCheckPoint = CheckPoints.Instance.GetNextCheckPoint();
                Vector3 lookDirection = nextCheckPoint.position - currenCheckPoint.position;
                lookDirection.y = 0;
                if (lookDirection != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                    transformToMove.rotation = targetRotation;
                }

                while (Vector3.Distance(transformToMove.position, nextCheckPoint.position) > 0.1f)
                {
                    transformToMove.position = Vector3.MoveTowards(
                        transformToMove.position, nextCheckPoint.position, movementSpeed * Time.deltaTime);
                    yield return null;
                }
                transformToMove.position = nextCheckPoint.position;
                CheckPoints.Instance.SetCurrentCheckPointIndexOnArrival();
                yield return null;
                ManageMovement(move); //Recursively calling the method again
            }

            void CleanCurrentCR()
            {
                if (currentCR == null) return;
                StopCoroutine(currentCR);
                currentCR = null;
            }
        }

        private void OnGameStateChange(GameStates gameState)
        {
            switch (gameState)
            {
                case GameStates.Initial:
                    //Stand idle
                    break;
                case GameStates.Playing:
                    //Run
                    ManageMovement(true);
                    break;
                case GameStates.Paused:
                    //Stand idle
                    ManageMovement(false);
                    break;
                default:
                    //Stand idle
                    break;
            }
        }
    }
}
