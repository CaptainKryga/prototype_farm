using UnityEngine.SceneManagement;

namespace View.Game
{
    public class MenuGamePause: MenuBase
    {
        public void OnClick_Continue()
        {
            SetEnable(false);
        }

        public void OnClick_Restart()
        {
            SceneManager.LoadScene(1);
        }

        public void OnClick_MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}