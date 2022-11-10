using System;
using Model.Components;
using Static;
using UnityEngine;
using UnityEngine.AI;

namespace Model
{
    public class CharapterFarmer : MonoBehaviour
    {
        // [SerializeField] private CustomAnimator animator;
        [SerializeField] private Rigidbody rigidbody;

        [SerializeField] private NavMeshAgent agent;
        // [SerializeField] private Transform point1, point2;
        //
        // [SerializeField] private GameObject boxSmall, boxMiddle;
		
        // private float startSpeed, startAcceleration;
		      //
        // public Transform GetTransform { get => worker; }
        // public Vector3 WorkerBodyStartPosition { get => workerBodyStartPosition; }
        // public Quaternion WorkerBodyStartRotation { get => workerBodyStartRotation; }

        private void Start()
        {
            agent.autoRepath = true;
            agent.autoTraverseOffMeshLink = true;
            agent.autoBraking = true;

            // startSpeed = agent.speed;
            // startAcceleration = agent.acceleration;

            rigidbody.isKinematic = true;
			
            // UpdateAnimation(0, 1);
        }

        public bool SetNextPosition(Vector3 position, float distance = 1)
        {
            agent.isStopped = false;
            rigidbody.isKinematic = false;
            agent.destination = position;

            if (Vector3.Distance(agent.transform.position, position) < distance)
            {
                rigidbody.isKinematic = true;
                return true;
            }
            return false;
        }

        private Func<PlantData, Cell, int> _saveFunc;
        private PlantData _savePlant;
        private Cell _saveCell;
        public void SetNextQuest(Func<PlantData, Cell, int> func, PlantData plant, Cell cell)
        {
            _saveFunc = func;
            _savePlant = plant;
            _saveCell = cell;

            SetNextPosition(cell.ParentPlant.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Cell>() == _saveCell)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                _saveFunc(_savePlant, _saveCell);
            }
        }

        // public void UpdateAnimation(float walk, float classic)
        // {
        //     // animator.UpdateAnimation(walk, classic);
        // }
        //
        // public void UpdateSpeed(float speed)
        // {
        //     agent.speed = startSpeed * speed;
        //     agent.acceleration = startAcceleration * speed * 2;
        // }
        //
        // public Transform GetTransformWorker()
        // {
        //     return worker;
        // }

        // public void UpdateVisibleItem(GameTypes.Item item, bool isFlag)
        // {
        //     if (item == GameTypes.Item.BoxSmall)
        //         boxSmall.SetActive(isFlag);
        //     else if (item == GameTypes.Item.BoxMiddle)
        //         boxMiddle.SetActive(isFlag);
        // }
        //
        // public bool CheckActualPath()
        // {
        //     return agent.hasPath;
        // }
    }
}
