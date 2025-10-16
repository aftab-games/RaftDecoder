using System.Collections;
using TMPro;
using UnityEngine;

namespace Aftab
{
    public class ToastPanel : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField]
        CanvasGroup toastCanvasGroup;
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
                //Alpha
                float startAlpha = 0.8f;
                float endAlpha = 0;
                float newAlpha;
                //Canvasgroup
                toastCanvasGroup.alpha = startAlpha;
                //Position
                float startY = 0;
                float endY = 350;
                float newY = startY;
                Vector2 newAnchoredPos = toastRectTr.anchoredPosition;
                //Timer
                float timer = 0f;

                while (timer < fadeDuration)
                {
                    timer += Time.deltaTime;
                    newAlpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);
                    toastCanvasGroup.alpha = newAlpha;
                    newY = Mathf.Lerp(startY, endY, timer / fadeDuration);
                    newAnchoredPos.y = newY;
                    toastRectTr.anchoredPosition = newAnchoredPos;
                    yield return null;
                }
            }
        }
    }
}
