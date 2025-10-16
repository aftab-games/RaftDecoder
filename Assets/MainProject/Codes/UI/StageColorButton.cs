using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Aftab
{
    public class StageColorButton : MonoBehaviour
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
            MainUI.Instance.ManageStageColorButtonClicked(buttonColor);
            MainUI.Instance.GetStageCheckTr().SetParent(transform);
            MainUI.Instance.GetStageCheckTr().localPosition = Vector3.zero;
        }

        public void SetButtonColor(Color btnColor)
        {
            buttonColor = btnColor;
            GetComponent<Image>().color = buttonColor;
        }
    }
}
