using System;
using System.Collections;
using Model.Components;
using Static;
using UnityEngine;
using UnityEngine.AI;

namespace Model
{
    public class CharaсterFarmer : MonoBehaviour
    {
        [SerializeField] private CameraCinematicController CameraCinematicController;
        [SerializeField] private Animator animator;

        [SerializeField] private NavMeshAgent agent;

        public bool IsBusy;
        private bool _isFarming;

        private void Start()
        {
            agent.autoRepath = true;
            agent.autoTraverseOffMeshLink = true;
            agent.autoBraking = true;
            
            animator.SetFloat(Blend, (int)GameTypes.Anim.Idle);
        }

        public bool SetNextPosition(Cell cell, float distance = 2)
        {
            animator.SetFloat(Blend, (int)GameTypes.Anim.Run);
            IsBusy = true;
            agent.isStopped = false;
            agent.destination = cell.ParentPlant.position;

            if (Vector3.Distance(agent.transform.position, cell.ParentPlant.position) <= distance)
            {
                agent.transform.LookAt(cell.ParentPlant);
                agent.transform.eulerAngles = new Vector3(0, agent.transform.eulerAngles.y, 0);
                animator.SetFloat(Blend, (int)GameTypes.Anim.Farming);
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
        private static readonly int Blend = Animator.StringToHash("Blend");

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
                animator.SetFloat(Blend, (int)GameTypes.Anim.Farming);
                
                agent.isStopped = true;
                agent.velocity = Vector3.zero;

                StartCoroutine(Delay(_savePlant.PlantUse, _saveCell));
            }
        }

        IEnumerator Delay(float delay, Cell cell)
        {
            if (_isFarming)
                yield break;

            _isFarming = true;
            cell.Image.enabled = true;
            cell.Image.color = Color.red;
            
            while (delay > 0)
            {
                delay -= Time.deltaTime;
                cell.Image.fillAmount = 1 - 1 / (_savePlant.PlantUse / delay);
                yield return new WaitForEndOfFrame();
            }

            animator.SetFloat(Blend, (int)GameTypes.Anim.Idle);
            cell.Image.enabled = false;
            IsBusy = false;
            CameraCinematicController.Restart();
            _saveFunc(_savePlant, _saveCell);
            _isFarming = false;
            yield break;
        }
    }
}
