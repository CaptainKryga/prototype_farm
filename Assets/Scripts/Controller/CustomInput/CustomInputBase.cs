using System;
using UnityEngine;

namespace Controller.CustomInput
{
    public abstract class CustomInputBase : MonoBehaviour
    {
        //key, isDownKey?, mousePosition
        public Action<KeyCode, bool, Vector2> InputMouse_Action;
        //key, isDownKey?
        public Action<KeyCode, bool> InputKeyboard_Action;
        
        private void Update()
        {
            SetupKeyboard();
        }

        protected abstract void SetupKeyboard();
    }
}
