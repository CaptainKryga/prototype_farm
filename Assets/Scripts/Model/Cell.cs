using System.Collections;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace Model
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image _img;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Color _colorDefault, _colorCustom;
        private Transform _parentPlant;

        public GameTypes.Level Level;

        private void Awake()
        {
            _img.transform.LookAt(Camera.main.transform);

            _colorDefault = _meshRenderer.material.color;
            _colorCustom = Color.red;

            Level = GameTypes.Level.Min;
        }

        public void SetUse(bool flag)
        {
            _meshRenderer.material.color = flag ? _colorCustom : _colorDefault;
        }

        IEnumerator PlantGrow(float delay, GameObject prefab)
        {
            while (delay > 0)
            {
                delay -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            Instantiate(prefab, _parentPlant);
            yield break;
        }
    }
}
