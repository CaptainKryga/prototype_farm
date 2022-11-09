using UnityEngine;

namespace Controller.CustomInput
{
    public class CustomInputGame: CustomInputBase
    {
        protected override void SetupKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                InputMouse_Action?.Invoke(KeyCode.Mouse0, true, Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.Escape))
                InputKeyboard_Action?.Invoke(KeyCode.Escape, true);
        }
    }
}