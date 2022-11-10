using System;
using System.Collections;
using Model.Components;
using UnityEngine;
using UnityEngine.AI;

namespace Model
{
    public class CharapterFarmer : MonoBehaviour
    {
        [SerializeField] private CameraCinematicController CameraCinematicController;
        // [SerializeField] private CustomAnimator animator;
        [SerializeField] private Rigidbody rigidbody;

        [SerializeField] private NavMeshAgent agent;

        public bool IsBusy;
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

        public bool SetNextPosition(Cell cell, float distance = 2)
        {
            IsBusy = true;
            agent.isStopped = false;
            agent.destination = cell.ParentPlant.position;

            if (Vector3.Distance(agent.transform.position, cell.ParentPlant.position) <= distance)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;

                StartCoroutine(Delay(_savePlant.PlantUse, _saveCell));
                return false;
            }
            return false;
        }

        private Func<PlantData, Cell, int> _saveFunc;
        private PlantData _savePlant;
        private Cell _saveCell;
        
        public void SetNextQuest(Func<PlantData, Cell, int> func, PlantData plant, Cell cell)
        {
            CameraCinematicController.Starter(cell.CamPoint);
            
            _saveFunc = func;
            _savePlant = plant;
            _saveCell = cell;

            SetNextPosition(cell);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Cell>() == _saveCell)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;

                StartCoroutine(Delay(_savePlant.PlantUse, _saveCell));
            }
        }

        IEnumerator Delay(float delay, Cell cell)
        {
            cell.Image.enabled = true;
            cell.Image.color = Color.red;
            
            while (delay > 0)
            {
                delay -= Time.deltaTime;
                cell.Image.fillAmount = 1 - 1 / (_savePlant.PlantUse / delay);
                yield return new WaitForEndOfFrame();
            }

            cell.Image.enabled = false;
            IsBusy = false;
            CameraCinematicController.Restart();
            _saveFunc(_savePlant, _saveCell);
            yield break;
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
