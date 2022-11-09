using System.Collections.Generic;
using Model.Components;
using Scriptable;
using Static;
using UnityEngine;

namespace Model
{
    public class GenerateMap : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private GameData _gameData;

        [SerializeField] private Transform _parent;

        public Cell[] Setup()
        {
            List<Cell> cells = new List<Cell>();
            Vector3 startPos = _parent.position +
                               -Vector3.right * _gameSettings.Width +
                               -Vector3.forward * _gameSettings.Height;

            for (int x = 0; x < _gameSettings.Width; x++)
            {
                for (int y = 0; y < _gameSettings.Height; y++)
                {
                    Vector3 nowPos = new Vector3(x * GameMetrics.KoofGenMapFromCell, 0, 
                        y * GameMetrics.KoofGenMapFromCell);
                    cells.Add(Instantiate(_gameData.PrefabCell, startPos + nowPos,
                        Quaternion.identity, _parent));
                }
            }

            return cells.ToArray();
        }
    }
}
