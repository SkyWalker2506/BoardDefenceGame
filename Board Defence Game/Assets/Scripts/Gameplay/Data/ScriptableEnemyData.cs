using UnityEngine;

namespace BoardDefenceGame.Data
{
    [CreateAssetMenu(fileName = "EnemyLevelData", menuName = "BoardDefenceGame/EnemyData")]
    public class ScriptableEnemyData : ScriptableObject
    {
        [SerializeField] private EnemyData[] enemyData;

        public IEnemyData[] GetEnemyData()
        {
            IEnemyData[] data = new IEnemyData[enemyData.Length];
            for (int i = 0; i < enemyData.Length; i++)
            {
                data[i] = enemyData[i];
            }
            return data;
        } 
    }
}