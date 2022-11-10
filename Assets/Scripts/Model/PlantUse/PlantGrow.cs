using System.Collections;
using Model.Components;
using UnityEngine;

namespace Model.PlantUse
{
    public class PlantGrow : PlantUseBase
    {
        protected override IEnumerator Use(PlantData plantData, Cell cell)
        {
            float delay = plantData.Grow;
            cell.Image.enabled = true;
            cell.Image.color = Color.white;
            
            while (delay > 0)
            {
                delay -= Time.deltaTime;
                cell.Image.fillAmount = 1 - 1 / (plantData.Grow / delay);
                yield return new WaitForEndOfFrame();
            }

            cell.Image.enabled = false;
            Instantiate(plantData.Prefab, cell.ParentPlant);
            
            ScorePlayer.Experience = (int)plantData.Grow * 10;
            
            cell.Plant = plantData.Type;
            yield break;
        }
    }
}
