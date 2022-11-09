using UnityEngine;

namespace View
{
    public class MenuBase : MonoBehaviour
    {
        [SerializeField] protected GameObject PanelBase;

        protected void SetEnable(bool enable)
        {
            PanelBase.SetActive(enable);
        }
    }
}
