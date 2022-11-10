using System.Collections;
using Model.Components;
using Static;
using UnityEngine;

namespace Model
{
    public class PlantGrow : MonoBehaviour
    {
        [SerializeField] private ScoreController _scoreController;
        
        public int Starter(PlantData plantData, Cell cell)
        {
            cell.Plant = GameTypes.Plant.Close;

            StartCoroutine(Grow(plantData, cell));

            return 0;
        }

        private IEnumerator Grow(PlantData plantData, Cell cell)
        {
            float delay = plantData.GrowDelay;
            cell.Image.enabled = true;
            while (delay > 0)
            {
                delay -= Time.deltaTime;
                cell.Image.fillAmount = 1 - 1 / (plantData.GrowDelay / delay);
                yield return new WaitForEndOfFrame();
            }

            cell.Image.enabled = false;
            Instantiate(plantData.Prefab, cell.ParentPlant);
            
            _scoreController.Experience = (int)plantData.GrowDelay * 10;
            
            cell.Plant = plantData.Type;
            yield break;
        }
    }
}
