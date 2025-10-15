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
        }

        private void Update()
        {
            CheckScreenOrientationAndManageFOV();
            Debug.Log("Screen Orientation: " + Screen.orientation);
        }

        private void CheckScreenOrientationAndManageFOV()
        {
            if (prevScreenOrientation == Screen.orientation) return;
            if(Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                mainCamera.fieldOfView = portraitFOV;
            }
            else
            {
                mainCamera.fieldOfView = landscapeFOV;
            }
            prevScreenOrientation = Screen.orientation;
        }
    }
}
