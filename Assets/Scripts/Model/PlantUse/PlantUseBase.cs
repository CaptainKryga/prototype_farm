using System.Collections;
using Model.Components;
using Model.Score;
using UnityEngine;

namespace Model.PlantUse
{
    public abstract class PlantUseBase: MonoBehaviour
    {
        [SerializeField] protected ScoreController ScorePlayer;
        
        public int Starter(PlantData plantData, Cell cell)
        {
            StartCoroutine(Use(plantData, cell));
            return 0;
        }
        
        protected abstract IEnumerator Use(PlantData plantData, Cell cell);
    }
}