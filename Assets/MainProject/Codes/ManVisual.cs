using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aftab
{
    public class ManVisual : MonoBehaviour
    {
        [SerializeField]
        Renderer visualRenderer;
        void Start()
        {
            MainUI.Instance.OnManColorButtonClicked += OnClickedColorButton;
        }

        private void OnDisable()
        {
            MainUI.Instance.OnManColorButtonClicked -= OnClickedColorButton;
        }

        private void OnClickedColorButton(Color buttonColor)
        {
            visualRenderer.material.color = buttonColor;
        }
    }
}
