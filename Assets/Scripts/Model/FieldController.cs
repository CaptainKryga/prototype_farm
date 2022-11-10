using Controller.CustomInput;
using Model.Components;
using Model.PlantUse;
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
        [SerializeField] private PlantGather _plantGather;

        [SerializeField] private CharaсterFarmer CharaсterFarmer;
        
        private CustomInputBase _customInput;
        private Cell[] _cells;
        private Cell _cellActual;

        private Camera _camera;

        [SerializeField] private MenuBase _menuBuy, _menuGather;
        
        public void Setup(Cell[] cells, CustomInputBase customInput)
        {
            _customInput = customInput;
            _cells = cells;
            _camera = Camera.main;

            _customInput.InputMouse_Action += ClickField;
        }

        private void ClickField(KeyCode key, bool flag, Vector2 mousePosition)
        {
            if (flag && key == KeyCode.Mouse0 && !_cellActual && !CharaсterFarmer.IsBusy)
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    _cellActual = hit.transform.GetComponent<Cell>();
                    if (_cellActual)
                    {
                        ClearCells();

                        if (_cellActual.Plant == GameTypes.Plant.Open)
                        {
                            _cellActual.SetUse(true);
                            ((MenuGameBuy) _menuBuy).Setup(mousePosition);
                        }
                        else if (_cellActual.Plant != GameTypes.Plant.Close &&
                                 _cellActual.Plant != GameTypes.Plant.Tree)
                        {
                            _cellActual.SetUse(true);
                            ((MenuGameGather) _menuGather).Setup(mousePosition, _cellActual.Plant);
                        }
                        else
                        {
                            _cellActual = null;
                        }
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

        public void PlantGrow(GameTypes.Plant type)
        {
            ClearCells();

            if (type != GameTypes.Plant.Close)
                CharaсterFarmer.SetNextQuest(_plantGrow.Starter, _gameData.GetPlantFromType(type), _cellActual);

            _cellActual = null;
        }
        public void PlantGather(GameTypes.Plant type)
        {
            ClearCells();
            
            if (type == GameTypes.Plant.Carrot || type == GameTypes.Plant.Grass)
                CharaсterFarmer.SetNextQuest(_plantGather.Starter, _gameData.GetPlantFromType(type), _cellActual);

            _cellActual = null;
        }

        private void OnDestroy()
        {
            _customInput.InputMouse_Action -= ClickField;
        }
    }
}
