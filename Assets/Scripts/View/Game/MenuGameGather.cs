using Controller;
using Static;
using UnityEngine;

namespace View.Game
{
    public class MenuGameGather : MenuBase
    {
        [SerializeField] private Global _global;
        [SerializeField] private GameObject _grass, _carrot;
        
        public void Setup(Vector2 position, GameTypes.Plant plant)
        {
            _carrot.SetActive(plant == GameTypes.Plant.Carrot);
            _grass.SetActive(plant == GameTypes.Plant.Grass);
            
            PanelBase.transform.position = position;
            SetEnable(true);
        }
        
        public void OnClick_GatherCarrot()
        {
            _global.GatherPlant(GameTypes.Plant.Carrot);
            SetEnable(false);
        }

        public void OnClick_GatherGrass()
        {
            _global.GatherPlant(GameTypes.Plant.Grass);
            SetEnable(false);
        }

        public void OnClick_Close()
        {
            _global.GatherPlant(GameTypes.Plant.Close);
            SetEnable(false);
        }
    }
}
