using Controller.CustomInput;
using Model.Components;
using Static;
using UnityEngine;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        [SerializeField] private CustomInputBase _customInput;
        
        [SerializeField] private GenerateMap _generateMap;
        [SerializeField] private FieldController _fieldController;
        public void Setup()
        {
            Cell[] cells = _generateMap.Setup();
            _fieldController.Setup(cells, _customInput);
        }

        public void BuyPlant(GameTypes.Plant type)
        {
            _fieldController.BuyPlant(type);
        }
    }
}
