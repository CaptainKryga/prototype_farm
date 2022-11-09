using UnityEngine;

namespace View.Main
{
    public class MenuMain : MenuMainBase
    {
        [SerializeField] private MenuMainBase _game;
        [SerializeField] private MenuMainBase _settings;
        [SerializeField] private MenuMainBase _authors;
        
        public void OnClick_Game()
        {
            _game.UsePanel(PanelBase);
            SetEnable(false);
        }

        public void OnClick_Settings()
        {
            _settings.UsePanel(PanelBase);
            SetEnable(false);
        }
        
        public void OnClick_Authors()
        {
            _authors.UsePanel(PanelBase);
            SetEnable(false);
        }

        public void OnClick_Exit()
        {
            Application.Quit();
        }
    }
}