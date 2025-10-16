using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aftab
{
    public class ToastPanel : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField]
        CanvasGroup toastCanvasGroup;
        [SerializeField]
        private Image bgImage;
        [SerializeField]
        private TextMeshProUGUI messageTMPro;
        [SerializeField]
        private RectTransform toastRectTr;
        private float fadeDuration;
        //300, 0.8
        public void ManageToastFloatingAndFadingWithMessage(string message, float fadeTime)
        {
            fadeDuration = fadeTime;
            toastRectTr.anchoredPosition = Vector2.zero;
            toastRectTr.offsetMin = new Vector2(0, toastRectTr.offsetMin.y);
            toastRectTr.offsetMax = new Vector2(0, toastRectTr.offsetMax.y);
            messageTMPro.text = message;
            StartCoroutine(FadeAndFloatImage());
            IEnumerator FadeAndFloatImage()
            {
                //Color
                Color currentColor = bgImage.color;
                bgImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.8f);
                currentColor = bgImage.color;
                Color newColor = currentColor;
                float startAlpha = 0.8f;
                float endAlpha = 0;
                float newAlpha;
                //Position
                Vector2 startAnchoredPos = Vector2.zero;
                Vector2 endAnchoredPos = new Vector2(0, 300);
                float startY = 0;
                float endY = endAnchoredPos.y;
                float newY = startY;
                Vector2 newAnchoredPos = startAnchoredPos;
                //Timer
                float timer = 0f;

                while (timer < fadeDuration)
                {
                    timer += Time.deltaTime;
                    newAlpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);
                    newColor.a = newAlpha;
                    bgImage.color = newColor; //new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
                    newY = Mathf.Lerp(startY, endY, timer / fadeDuration);
                    newAnchoredPos.y = newY;
                    toastRectTr.anchoredPosition = newAnchoredPos;
                    yield return null;
                }
                //newColor.a = endAlpha;
                //bgImage.color = newColor; //new Color(currentColor.r, currentColor.g, currentColor.b, endAlpha);
                //newAnchoredPos.y = endY;
                //toastRectTr.anchoredPosition = newAnchoredPos;
            }
        }
    }
}
