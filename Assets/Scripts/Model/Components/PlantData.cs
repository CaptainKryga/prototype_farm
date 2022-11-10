using System;
using Static;
using UnityEngine;

namespace Model.Components
{
    [Serializable]
    public class PlantData
    {
        public GameTypes.Plant Type;
        //delay and experience
        public float Grow;
        public float PlantUse;
        public GameObject Prefab;
    }
}
