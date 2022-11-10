using System;
using Model;
using Static;
using UnityEngine;

namespace Controller
{
    public class Global : MonoBehaviour
    {
        [SerializeField] private ModelController _modelController;

        private void Awake()
        {
            _modelController.Setup();
        }

        public void PlantGrow(GameTypes.Plant type)
        {
            _modelController.PlantGrow(type);
        }

        public void PlantGather(GameTypes.Plant type)
        {
            _modelController.PlantGather(type);
        }
    }
}
