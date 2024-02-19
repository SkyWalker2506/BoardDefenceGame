using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    [CreateAssetMenu(fileName = "BoardData", menuName = "BoardDefenceGame/BoardData", order = 0)]
    public class ScriptableBoardData : ScriptableObject, IBoardData
    {
        [field:SerializeField] public Vector3 BoardPosition { get; private set; }
        [field:SerializeField] public Vector3 LineOffset { get; private set; }
        [field:SerializeField] public int LineCount { get; private set; }
        [field:SerializeField] public Vector3 TileOffset { get; private set; }
        [field:SerializeField] public int TileCount { get; private set; }
        
    }
}