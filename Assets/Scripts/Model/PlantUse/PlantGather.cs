using System.Collections;
using Model.Components;
using Static;

namespace Model.PlantUse
{
    public class PlantGather : PlantUseBase
    {
        protected override IEnumerator Use(PlantData plantData, Cell cell)
        {
            for (int x = 0; x < cell.ParentPlant.childCount; x++)
            {
                Destroy(cell.ParentPlant.GetChild(x).gameObject);
            }

            cell.Plant = GameTypes.Plant.Open;
            
            if (plantData.Type == GameTypes.Plant.Carrot)
                ScoreController.CarrotScore = 1;
            
            yield break;
        }
    }
}
