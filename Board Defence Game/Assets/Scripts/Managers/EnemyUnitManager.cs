using System.Collections.Generic;
using BoardDefenceGame.Data;
using BoardDefenceGame.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    public class EnemyUnitManager : MonoBehaviour
    {
        [Inject] private BoardPresenter boardPresenter;
        private List<IEnemyData> enemies;
        private List<EnemyMoveData> movableEnemies = new ();
        
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

        private void Update()
        {
            foreach (EnemyMoveData movableEnemy in movableEnemies)
            {
                MoveEnemyToNextTile(movableEnemy);
            }
            movableEnemies.RemoveAll(enemy => enemy.IsMovementEnded);
        }

        private void CreateEnemyUnits()
        {
            if (enemies.Count == 0)
            {
                CancelInvoke(nameof(CreateEnemyUnits));
                return;
            }
            var enemy = CreateEnemyUnit();
            var line = boardPresenter.GetRandomLine();
            var tile = line.GetLastTile();
            enemy.transform.position = tile.GetTilePosition();
            enemy.SetIndex(tile.GetLineIndex(), tile.GetTileIndex());
            movableEnemies.Add(new EnemyMoveData{Enemy = enemy, MoveStep = 0});
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
        
        private void MoveEnemyToNextTile(EnemyMoveData movableEnemy)
        {
            var enemy = movableEnemy.Enemy;
            var lineIndex = enemy.GetLineIndex();
            var line = boardPresenter.GetLine(lineIndex);
            var currentTile = line.GetTile(enemy.GetTileIndex());
            Vector3 nextPosition;
            TilePresenter nextTile = null;
            if (currentTile.GetTileIndex() == 0)
            {
                nextPosition = line.GetFinishLinePosition();
            }
            else
            {
                nextTile = line.GetTile(enemy.GetTileIndex() - 1);
                nextPosition = nextTile.GetTilePosition();
            }
            
            movableEnemy.MoveStep += enemy.GetMovementSpeed()*Time.deltaTime;
            var newPosition = Vector3.Lerp(currentTile.GetTilePosition() , nextPosition , movableEnemy.MoveStep);
            enemy.SetPosition(newPosition);
            if (movableEnemy.MoveStep >= 1)
            {
                if(currentTile.GetTileIndex() == 0)
                {
                    movableEnemy.IsMovementEnded = true;
                    enemy.SetIndex(-1, -1);
                }
                else
                {
                    enemy.SetIndex(nextTile.GetLineIndex(), nextTile.GetTileIndex());
                    movableEnemy.MoveStep = 0;
                }
            }
        }
    }
}

class EnemyMoveData
{
    public EnemyUnitPresenter Enemy;
    public float MoveStep;
    public bool IsMovementEnded;
}