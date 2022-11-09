using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Range(2, 10)]
        public int Width;
        [Range(2, 10)]
        public int Height;
    }
}
