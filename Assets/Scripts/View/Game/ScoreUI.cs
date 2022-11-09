using TMPro;
using UnityEngine;

namespace View.Game
{
    public class ScoreUI: MonoBehaviour
    {
        [SerializeField] private TMP_Text _textCarrot, _textExperience;

        private void Start()
        {
            UpdateCarrot(0);
            UpdateExperience(0);
        }

        public void UpdateCarrot(int carrot)
        {
            _textCarrot.text = "Carrot: " + carrot;
        }
        
        public void UpdateExperience(int experience)
        {
            _textExperience.text = "Experience: " + experience;
        }
    }
}