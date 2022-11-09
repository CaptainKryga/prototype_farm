using UnityEngine;

namespace Utils
{
    public class QSettings: MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 1;
        }
    }
}