using UnityEngine;

namespace Aftab
{
    public class DynamicCameraFOV : MonoBehaviour
    {
        [SerializeField]
        float portraitFOV = 60.0f;
        [SerializeField]
        float landscapeFOV = 33.0f;
        private Camera mainCamera;
        private ScreenOrientation prevScreenOrientation;
        void Start()
        {
            mainCamera = GetComponent<Camera>();
            prevScreenOrientation = Screen.orientation;
            ManageFOV();
        }

        private void Update()
        {
            CheckScreenOrientationAndManageFOV();
        }

        private void CheckScreenOrientationAndManageFOV()
        {
            if (prevScreenOrientation == Screen.orientation) return;
            ManageFOV();
            prevScreenOrientation = Screen.orientation;
        }

        private void ManageFOV()
        {
            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                mainCamera.fieldOfView = portraitFOV;
            }
            else
            {
                mainCamera.fieldOfView = landscapeFOV;
            }
            //float currentAspectRatio = (float)Screen.width / Screen.height;
            //float verticalFOV = 2f * Mathf.Atan(Mathf.Tan(desiredHorizontalFOV * 0.5f * Mathf.Deg2Rad) / currentAspectRatio) * Mathf.Rad2Deg;
        }
    }
}
