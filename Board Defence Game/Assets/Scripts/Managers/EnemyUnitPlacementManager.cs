using System.Collections.Generic;
using BoardDefenceGame.Data;
using BoardDefenceGame.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    public class EnemyUnitPlacementManager : MonoBehaviour
    {
        [Inject] private BoardPresenter boardPresenter;
        private List<IEnemyData> enemies;
        public void InitializeEnemyUnits(IEnemyData[] enemyData)
        {
            enemies = new List<IEnemyData>();
            foreach (var data in enemyData)
            {
                if (data.EnemyUnitCount > 0)
                {
                    enemies.Add(data);
                }
            }
            InvokeRepeating(nameof(CreateEnemyUnits), 1, 1);
        }

        private void CreateEnemyUnits()
        {
            var enemy = CreateEnemyUnit();
            var line = boardPresenter.GetRandomLine();
            var tile = line.GetLastTile();
            enemy.transform.position = tile.GetTilePosition();
            enemy.SetIndex(tile.GetLineIndex(), tile.GetTileIndex());
            if (enemies.Count == 0)
            {
                CancelInvoke(nameof(CreateEnemyUnits));
            }
        }

        private EnemyUnitPresenter CreateEnemyUnit()
        {
            int index = Random.Range(0, enemies.Count);
            EnemyUnitPresenter enemyUnitPrefab = enemies[index].EnemyUnitPrefab;      
            var enemyUnit = Instantiate(enemyUnitPrefab);
            enemies[index].EnemyUnitCount--;
            if (enemies[index].EnemyUnitCount <= 0)
            {
                enemies.RemoveAt(index);
            }

            return enemyUnit;
        }
    }
}