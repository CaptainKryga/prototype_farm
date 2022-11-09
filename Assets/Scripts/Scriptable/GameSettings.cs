using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Range(2, 20)]
        public int Width;
        [Range(2, 20)]
        public int Height;
    }
}
