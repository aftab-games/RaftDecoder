using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aftab
{
    public class IslandVisual : MonoBehaviour
    {
        [SerializeField]
        Renderer visualRenderer;
        void Start()
        {
            MainUI.Instance.OnStageColorButtonClicked += OnClickedColorButton;
        }

        private void OnDisable()
        {
            MainUI.Instance.OnStageColorButtonClicked -= OnClickedColorButton;
        }

        private void OnClickedColorButton(Color buttonColor)
        {
            visualRenderer.material.color = buttonColor;
        }
    }
}
