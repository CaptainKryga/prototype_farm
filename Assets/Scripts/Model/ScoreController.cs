using System.Collections;
using UnityEngine;
using View.Game;

namespace Model
{
    //разбить на 2 скрипта отвечающие каждый за свой параметр inventory and player
    public class ScoreController: MonoBehaviour
    {
        private int _carrotScore;
        private int _experience;

        [SerializeField] private ScoreUI _scoreUI;

        public int CarrotScore
        {
            get => _carrotScore;
            set => StartCoroutine(UpdateCarrot(value));
        }

        public int Experience
        {
            get => _experience;
            set => StartCoroutine(UpdateExperience(value));
        }

        private IEnumerator UpdateCarrot(int value)
        {
            while (value > 0)
            {
                _scoreUI.UpdateCarrot(++_carrotScore);
                value--;
                yield return new WaitForEndOfFrame();
            }
            yield break;
        }

        private IEnumerator UpdateExperience(int value)
        {
            while (value > 0)
            {
                _scoreUI.UpdateExperience(++_experience);
                value--;
                yield return new WaitForEndOfFrame();
            }
            yield break;
        }
    }
}