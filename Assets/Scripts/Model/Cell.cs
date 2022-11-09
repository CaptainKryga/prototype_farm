using UnityEngine;
using UnityEngine.UI;

namespace Model
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image _img;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _img.transform.LookAt(_camera.transform);
        }
    }
}
