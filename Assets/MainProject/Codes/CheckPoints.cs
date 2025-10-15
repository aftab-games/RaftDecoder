using System.Collections.Generic;
using UnityEngine;

namespace Aftab
{
    public class CheckPoints : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField]
        List<Transform> checkPointsTr = new List<Transform>();
        int currentCheckPointIndex = 0;

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
