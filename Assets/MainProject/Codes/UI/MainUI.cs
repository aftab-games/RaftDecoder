using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Aftab
{
    public class MainUI : MonoBehaviour
    {
        public static MainUI Instance { get; private set; }

        [Header("Buttons And Settings:")]
        [SerializeField]
        private Button startButton;
        [SerializeField]
        private Button settingButton;
        [SerializeField]
        private Button crossButton;
        [SerializeField]
        private GameObject settingPanelGO;
        [Header("Tabs")]
        [SerializeField]
        private Button manColorTabButton;
        [SerializeField]
        private Button stageColorTabButton;
        [SerializeField]
        private GameObject manColorScrollViewGO;
        [SerializeField]
        private GameObject stageColorScrollViewGO;
        [SerializeField]
        private Transform manCheckTr;
        [SerializeField]
        private Transform stageCheckTr;

        [SerializeField]
        private GameObject manColorButtonGO;
        [SerializeField]
        private GameObject stageColorButtonGO;

        [SerializeField]
        private GameObject manColorButtonsHolder;
        [SerializeField]
        private GameObject stageColorButtonsHolder;

        [SerializeField]
        private List<Color> manColors = new List<Color>();
        [SerializeField]
        private List<Color> stageColors = new List<Color>();

        public event Action<Color> OnManColorButtonClicked, OnStageColorButtonClicked;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            startButton.onClick.AddListener(()=> OnStartButtonClicked());
            settingButton.onClick.AddListener(() => OnSettingButtonClicked());
            crossButton.onClick.AddListener(()=> OnCrossButtonClicked());
            manColorTabButton.onClick.AddListener(() => { OnClickedManColorTabButton(); });
            stageColorTabButton.onClick.AddListener(() => { OnClickedStageColorTabButton(); });
            PopulateTabButtons();
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(()=> OnStartButtonClicked());
            settingButton.onClick.RemoveListener(()=> OnSettingButtonClicked());
            crossButton.onClick.RemoveListener(()=> OnCrossButtonClicked());
            manColorTabButton.onClick.RemoveListener(() => { OnClickedManColorTabButton(); });
            stageColorTabButton.onClick.RemoveListener(() => { OnClickedStageColorTabButton(); });
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
            settingPanelGO.SetActive(true);
        }

        private void OnCrossButtonClicked()
        {
            GameStateManager.Instance.SetGameState(GameStates.Playing);
            settingPanelGO.SetActive(false);
            settingButton.gameObject.SetActive(true);
        }

        private void OnClickedManColorTabButton()
        {
            manColorScrollViewGO.SetActive(true);
            stageColorScrollViewGO.SetActive(false);
        }

        private void OnClickedStageColorTabButton()
        {
            manColorScrollViewGO.SetActive(false);
            stageColorScrollViewGO.SetActive(true);
        }

        private void PopulateTabButtons()
        {
            PopulateManColorButtons();
            PopulateStageColorButtons();

            void PopulateManColorButtons()
            {
                for (int i = 0; i < manColors.Count; i++)
                {
                    GameObject go = Instantiate(manColorButtonGO);
                    go.transform.SetParent(manColorButtonsHolder.transform, false);
                    go.transform.localPosition = Vector3.zero;
                    go.GetComponent<ManColorButton>().SetButtonColor(manColors[i]);
                    go.SetActive(true);
                }
            }

            void PopulateStageColorButtons()
            {
                for (int i = 0; i < stageColors.Count; i++)
                {
                    GameObject go = Instantiate(stageColorButtonGO);
                    go.transform.SetParent(stageColorButtonsHolder.transform, false);
                    go.transform.localPosition = Vector3.zero;
                    go.GetComponent<StageColorButton>().SetButtonColor(manColors[i]);
                    go.SetActive(true);
                }
            }
        }

        public void ManageManColorButtonClicked(Color buttonColor)
        {
            OnManColorButtonClicked?.Invoke(buttonColor);
        }

        public Transform GetManCheckTr() => manCheckTr;
        public Transform GetStageCheckTr() => stageCheckTr;

        public void ManageStageColorButtonClicked(Color buttonColor)
        {
            OnStageColorButtonClicked?.Invoke(buttonColor);
        }
    }
}
