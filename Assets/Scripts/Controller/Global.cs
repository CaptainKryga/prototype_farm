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

        public void BuyPlant(GameTypes.Plant type)
        {
            _modelController.BuyPlant(type);
        }

        public void GatherPlant(GameTypes.Plant type)
        {
            _modelController.GatherPlant(type);
        }
    }
}
