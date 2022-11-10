using System;
using System.Collections;
using Model.Components;
using Static;
using UnityEngine;
using UnityEngine.AI;

namespace Model
{
    public class CharacterFarmer : MonoBehaviour
    {
        [SerializeField] private CameraCinematicController CameraCinematicController;
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;

        private static readonly int Blend = Animator.StringToHash("Blend");
        
        public bool IsBusy;
        private bool _isFarming;

        private Func<PlantData, Cell, int> _saveFunc;
        private PlantData _savePlant;
        private Cell _saveCell;
        
        private void Start()
        {
            _agent.autoRepath = true;
            _agent.autoTraverseOffMeshLink = true;
            _agent.autoBraking = true;
            
            _animator.SetFloat(Blend, (int)GameTypes.Anim.Idle);
        }

        private void SetNextPosition(Cell cell, float distance = 2)
        {
            _animator.SetFloat(Blend, (int)GameTypes.Anim.Run);
            IsBusy = true;
            _agent.isStopped = false;
            _agent.destination = cell.ParentPlant.position;

            if (Vector3.Distance(_agent.transform.position, cell.ParentPlant.position) <= distance)
            {
                _agent.transform.LookAt(cell.ParentPlant);
                _agent.transform.eulerAngles = new Vector3(0, _agent.transform.eulerAngles.y, 0);
                _animator.SetFloat(Blend, (int)GameTypes.Anim.Farming);
                _agent.isStopped = true;
                _agent.velocity = Vector3.zero;

                StartCoroutine(Delay(_savePlant.PlantUse, _saveCell));
            }
        }
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
                _animator.SetFloat(Blend, (int)GameTypes.Anim.Farming);
                
                _agent.isStopped = true;
                _agent.velocity = Vector3.zero;

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

            _animator.SetFloat(Blend, (int)GameTypes.Anim.Idle);
            cell.Image.enabled = false;
            IsBusy = false;
            _isFarming = false;
            CameraCinematicController.Restart();
            _saveFunc(_savePlant, _saveCell);
            yield break;
        }
    }
}
