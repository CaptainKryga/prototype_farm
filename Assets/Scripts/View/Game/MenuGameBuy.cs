using Controller;
using Static;
using UnityEngine;

namespace View.Game
{
    public class MenuGameBuy : MenuBase
    {
        [SerializeField] private Global _global;
        
        public void Setup(Vector2 position)
        {
            PanelBase.transform.position = position;
            SetEnable(true);
        }
        
        public void OnClick_BuyCarrot()
        {
            _global.BuyPlant(GameTypes.Plant.Carrot);
            SetEnable(false);
        }

        public void OnClick_ButTree()
        {
            _global.BuyPlant(GameTypes.Plant.Tree);
            SetEnable(false);
        }

        public void OnClick_BuyGrass()
        {
            _global.BuyPlant(GameTypes.Plant.Grass);
            SetEnable(false);
        }

        public void OnClick_Close()
        {
            _global.BuyPlant(GameTypes.Plant.Close);
            SetEnable(false);
        }
    }
}
