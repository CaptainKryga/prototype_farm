using Model.Components;
using Static;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
    public class GameData : ScriptableObject
    {
        public Cell PrefabCell;
        public PlantData[] PlantData;

        public PlantData GetPlantFromType(GameTypes.Plant type)
        {
            foreach (var plant in PlantData)
            {
                if (plant.Type == type)
                    return plant;
            }

            return null;
        }
    }
}
