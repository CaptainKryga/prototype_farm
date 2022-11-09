using Model;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
    public class GameData : ScriptableObject
    {
        public Cell PrefabCell;
    }
}
