using System;
using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.Data
{
    [CreateAssetMenu(fileName = "EnemyLevelData", menuName = "BoardDefenceGame/EnemyLevelData")]
    public class ScriptableEnemyLevelDataList : ScriptableObject
    {
        public EnemyLevelData[] EnemyLevelData;
    }
    
    [Serializable]
    public struct EnemyLevelData
    {
        public EnemyUnitPresenter EnemyUnitPrefab;
        public int EnemyUnitCount;
    }
}