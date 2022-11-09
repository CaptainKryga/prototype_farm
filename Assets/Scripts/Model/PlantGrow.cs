using System.Collections;
using Model.Components;
using UnityEngine;

namespace Model
{
    public class PlantGrow : MonoBehaviour
    {
        public void Starter(PlantData plantData, Cell cell)
        {
            StartCoroutine(Grow(plantData, cell));
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
            yield break;
        }
    }
}
