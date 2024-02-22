using BoardDefenceGame.UI.MVP.Model;
using UnityEngine;

namespace BoardDefenceGame.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "BoardDefenceGame/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public ScriptableEnemyLevelDataList EnemyUnitData;
        public ScriptableDefenceUnitPanelData DefenceUnitData;
    }
}