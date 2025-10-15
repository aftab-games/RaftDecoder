using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aftab
{
    public class TheManMovement : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField]
        Transform transformToMove;
        [SerializeField]
        float movementSpeed = 5.0f;

        bool canMove = false;

        GameStateManager gameStateManager;

        private void Start()
        {
            gameStateManager = GameStateManager.Instance;
            gameStateManager.OnGameStateChanged += OnGameStateChange;
        }

        private void OnDisable()
        {
            gameStateManager.OnGameStateChanged -= OnGameStateChange;
        }

        private void OnGameStateChange(GameStates gameState)
        {
            switch (gameState)
            {
                case GameStates.Initial:
                    //Stand idle
                    canMove = false;
                    break;
                case GameStates.Playing:
                    //Run
                    canMove = true;
                    break;
                case GameStates.Paused:
                    //Stand idle
                    canMove = false;
                    break;
                default:
                    //Stand idle
                    canMove = false;
                    break;
            }
        }
    }
}
