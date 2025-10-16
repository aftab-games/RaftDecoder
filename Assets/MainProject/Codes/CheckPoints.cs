using System.Collections.Generic;
using UnityEngine;

namespace Aftab
{
    public class CheckPoints : MonoBehaviour
    {
        public static CheckPoints Instance { get; private set; }
        [Header("Settings:")]
        [SerializeField]
        private List<Transform> checkPointsTr = new List<Transform>();
        private int currentCheckPointIndex = 0;

        private void Awake()
        {
            Instance = this;
        }
        public Transform GetCurrentCheckPoint()
        {
            if (checkPointsTr == null) return null;
            if (checkPointsTr.Count <= 0) return null;
            return checkPointsTr[currentCheckPointIndex];
        }

        public void SetCurrentCheckPointIndexOnArrival()
        {
            currentCheckPointIndex++;
            if (currentCheckPointIndex >= checkPointsTr.Count) currentCheckPointIndex = 0;
            ToastCanvas.Instance.ManageToast("Passing point " + currentCheckPointIndex);
        }

        public Transform GetNextCheckPoint()
        {
            if (checkPointsTr == null) return null;
            if (checkPointsTr.Count <= 0) return null;
            int nextCheckPointIndex = currentCheckPointIndex + 1;
            if (nextCheckPointIndex >= checkPointsTr.Count) nextCheckPointIndex = 0;
            return checkPointsTr[nextCheckPointIndex];
        }
    }
}
