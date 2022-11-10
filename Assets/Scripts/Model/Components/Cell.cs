using Static;
using UnityEngine;
using UnityEngine.UI;

namespace Model.Components
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image _img;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Color _colorDefault, _colorCustom;
        public Transform ParentPlant;
        public Transform CamPoint;

        public GameTypes.Plant Plant;
        
        public Image Image { get => _img; }

        private void Awake()
        {
            _img.transform.LookAt(CamPoint);
            _img.enabled = false;

            _colorDefault = _meshRenderer.material.color;
            _colorCustom = Color.red;

            Plant = GameTypes.Plant.Open;
        }

        public void SetUseMaterial(bool flag)
        {
            _meshRenderer.material.color = flag ? _colorCustom : _colorDefault;
        }
    }
}
