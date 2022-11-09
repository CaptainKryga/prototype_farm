using Controller.CustomInput;
using Model.Components;
using Scriptable;
using Static;
using UnityEngine;
using View;
using View.Game;

namespace Model
{
    public class FieldController : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private PlantGrow _plantGrow;
        
        private CustomInputBase _customInput;
        private Cell[] _cells;
        private Cell _cellActual;

        private Camera _camera;
        
        [SerializeField] private MenuBase _menuBuy;
        
        public void Setup(Cell[] cells, CustomInputBase customInput)
        {
            _customInput = customInput;
            _cells = cells;
            _camera = Camera.main;

            _customInput.InputMouse_Action += ClickField;
        }

        private void ClickField(KeyCode key, bool flag, Vector2 mousePosition)
        {
            if (flag && key == KeyCode.Mouse0 && !_cellActual)
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    _cellActual = hit.transform.GetComponent<Cell>();
                    if (_cellActual)
                    {
                        ClearCells();
                        
                        _cellActual.SetUse(true);
                        ((MenuGameBuy) _menuBuy).Setup(mousePosition);
                    }
                }
            }
        }

        private void ClearCells()
        {
            for (int x = 0; x < _cells.Length; x++)
            {
                _cells[x].SetUse(false);
            }
        }

        public void BuyPlant(GameTypes.Plant type)
        {
            ClearCells();

            _plantGrow.Starter(_gameData.GetPlantFromType(type), _cellActual);

            _cellActual = null;
        }

        private void OnDestroy()
        {
            _customInput.InputMouse_Action -= ClickField;
        }
    }
}
