using System;
using Controller.CustomInput;
using UnityEngine;

namespace Model
{
    public class FieldController : MonoBehaviour
    {
        private CustomInputBase _customInput;
        private Cell[] _cells;
        
        public void Setup(Cell[] cells, CustomInputBase customInput)
        {
            _customInput = customInput;
            _cells = cells;
            
            _customInput.InputMouse_Action += ClickField;
        }

        private void ClickField(KeyCode key, bool flag, Vector2 mousePosition)
        {
            
        }

        private void OnDestroy()
        {
            _customInput.InputMouse_Action -= ClickField;
        }
    }
}
