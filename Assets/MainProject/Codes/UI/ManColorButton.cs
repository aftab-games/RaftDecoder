using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aftab
{
    public class ManColorButton : MonoBehaviour
    {
        [SerializeField]
        private Color buttonColor;
        private Button colorButton;

        private void OnEnable()
        {
            colorButton = GetComponent<Button>();
            colorButton.onClick.AddListener(() => { OnClickedButton(); });
        }

        private void OnDisable()
        {
            colorButton.onClick.RemoveListener(() => { OnClickedButton(); });
        }

        private void OnClickedButton()
        {
            MainUI.Instance.ManageManColorButtonClicked(buttonColor);
            MainUI.Instance.GetManCheckTr().SetParent(transform);
            MainUI.Instance.GetManCheckTr().localPosition = Vector3.zero;
        }

        public void SetButtonColor(Color btnColor)
        {
            buttonColor = btnColor;
            GetComponent<Image>().color = buttonColor;
        }
    }
}
