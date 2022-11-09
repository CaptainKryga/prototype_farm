using Controller.CustomInput;
using UnityEngine;
using View;
using View.Game;

namespace Model
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private CustomInputBase _customInput;
        [SerializeField] private MenuBase _pausePanel;
        
        private void OnEnable()
        {
            _customInput.InputKeyboard_Action += Pause;
        }

        private void OnDisable()
        {
            _customInput.InputKeyboard_Action -= Pause;
        }

        private void Pause(KeyCode key, bool isDown)
        {
            ((MenuGamePause)_pausePanel).ChangePauseState();
        }
    }
}
