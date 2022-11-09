using UnityEngine.SceneManagement;

namespace View.Main
{
    public class MenuMainGame: MenuMainBase
    {
        public void OnClick_NewGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}