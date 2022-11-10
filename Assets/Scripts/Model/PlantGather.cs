using System.Collections;
using Model.Components;
using Static;
using UnityEngine;

namespace Model
{
    public class PlantGather : MonoBehaviour
    {
        [SerializeField] private ScoreController _scoreController;

        public void Starter(PlantData plantData, Cell cell)
        {
            StartCoroutine(Gather(plantData, cell));
        }

        private IEnumerator Gather(PlantData plantData, Cell cell)
        {
            for (int x = 0; x < cell.ParentPlant.childCount; x++)
            {
                Destroy(cell.ParentPlant.GetChild(x).gameObject);
            }

            cell.Plant = GameTypes.Plant.Open;
            
            if (plantData.Type == GameTypes.Plant.Carrot)
                _scoreController.CarrotScore = 1;
            
            yield break;
        }
    }
}
