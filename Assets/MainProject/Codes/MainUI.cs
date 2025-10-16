using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aftab
{
    public class MainUI : MonoBehaviour
    {
        public static MainUI Instance { get; private set; }

        [SerializeField]
        Button startButton, settingButton;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            startButton.onClick.AddListener(()=> OnStartButtonClicked());
            settingButton.onClick.AddListener(() => OnSettingButtonClicked());
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(()=> OnStartButtonClicked());
            settingButton.onClick.RemoveListener(()=> OnSettingButtonClicked());
        }

        private void OnStartButtonClicked()
        {
            GameStateManager.Instance.SetGameState(GameStates.Playing);
            startButton.gameObject.SetActive(false);
            settingButton.gameObject.SetActive(true);
        }

        private void OnSettingButtonClicked()
        {
            GameStateManager.Instance.SetGameState(GameStates.Paused);
            settingButton.gameObject.SetActive(false);
        }
    }
}
