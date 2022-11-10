using System.Collections;
using UnityEngine;
using View.Game;

namespace Model.Score
{
    public class ScoreController: MonoBehaviour
    {
        [SerializeField] private ScoreUI _scoreUI;
        
        private int _carrotScore;
        private int _experience;

        public int CarrotScore
        {
            set => StartCoroutine(UpdateCarrot(value));
        }

        public int Experience
        {
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