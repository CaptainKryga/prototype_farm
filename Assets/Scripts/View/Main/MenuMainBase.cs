using Model;
using UnityEngine;

namespace View.Main
{
    public abstract class MenuMainBase : MenuBase
    {
        [SerializeField] private Transform _point;
        [SerializeField] private CameraCinematicController _cameraCinematicController;
        private GameObject _panelBack;

        public void UsePanel(GameObject panelBack)
        {
            _panelBack = panelBack;
            SetEnable(true);
            
            _cameraCinematicController.Starter(_point);
        }

        public void OnClick_Back()
        {
            SetEnable(false);
            _panelBack.SetActive(true);
            
            _cameraCinematicController.Restart();
        }
    }
}