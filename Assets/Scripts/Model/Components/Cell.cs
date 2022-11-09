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
        [SerializeField] private Transform _parentPlant;

        public GameTypes.Level Level;
        
        public Transform ParentPlant { get => _parentPlant; }
        public Image Image { get => _img; }

        private void Awake()
        {
            _img.transform.LookAt(Camera.main.transform);
            _img.enabled = false;

            _colorDefault = _meshRenderer.material.color;
            _colorCustom = Color.red;

            Level = GameTypes.Level.Min;
        }

        public void SetUse(bool flag)
        {
            _meshRenderer.material.color = flag ? _colorCustom : _colorDefault;
        }
    }
}
