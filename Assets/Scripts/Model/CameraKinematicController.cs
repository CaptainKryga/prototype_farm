using System;
using System.Collections;
using UnityEngine;

namespace Model
{
    public class CameraKinematicController : MonoBehaviour
    {
        [SerializeField] private Transform _startTransform;
        private Transform _camera;
        private int _id;

        private void Awake()
        {
            _camera = Camera.main.transform;
        }

        public void Starter(Transform target)
        {
            StartCoroutine(CamMove(target));
        }

        public void Restart()
        {
            StartCoroutine(CamMove(_startTransform));
        }

        IEnumerator CamMove(Transform target)
        {
            _id++;
            int tempId = _id;
            while (Vector3.Distance(_camera.position, target.position) > .1f)
            {
                if (tempId != _id)
                    break;
                
                _camera.position = Vector3.MoveTowards(_camera.position, 
                    target.position, Time.deltaTime * 10);
                _camera.rotation = Quaternion.LerpUnclamped(_camera.rotation, 
                    target.rotation, Time.deltaTime * 3);

                Debug.Log("Coroutina");
                yield return new WaitForEndOfFrame();
            }

            yield break;
        }
    }
}