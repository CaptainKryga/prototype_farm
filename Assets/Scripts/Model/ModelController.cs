using Controller.CustomInput;
using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        [SerializeField] private CustomInputBase _customInput;
        
        [SerializeField] private GenerateMap _generateMap;
        [SerializeField] private FieldController _fieldController;
        private void Start()
        {
            Cell[] cells = _generateMap.Setup();
            _fieldController.Setup(cells, _customInput);
        }
    }
}
