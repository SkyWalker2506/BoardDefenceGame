using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.Presenter;
using DependencyInjection;
using Unity.Mathematics;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    public class BattleManager : MonoBehaviour
    {
        [Inject] private DefenceUnitPlacementManager defenceUnitPlacementManager;
        [Inject] private BoardPresenter boardPresenter;


        private void Update()
        {
            var defenceUnits = defenceUnitPlacementManager.GetPlacedDefenceUnits();
            foreach (var defenceUnit in defenceUnits)
            {
                AttackToEnemy(defenceUnit);
            }
        }

        private void AttackToEnemy(DefenceUnitPresenter defenceUnit)
        {
            var enemy = GetEnemy(defenceUnit);
//            Debug.Log("Enemy "+enemy);
            if (enemy != null)
            {
                if (defenceUnit.TryAttack())
                {
                    enemy.TakeDamage(defenceUnit.GetDamageValue());
                }
            }
        }

        private EnemyUnitPresenter GetEnemy(DefenceUnitPresenter defenceUnit)
        {
            var line = boardPresenter.GetLine(defenceUnit.GetLineIndex());
            var tileIndex = defenceUnit.GetTileIndex();
            int range = defenceUnit.GetAttackRange();
            var lastIndex = math.min(tileIndex + range, line.GetTileCount() - 1);
            var firstIndex = defenceUnit.GetDirection()==Direction.forward?tileIndex:math.max(tileIndex-range,0);
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                TilePresenter tile = line.GetTile(i);
                
//                Debug.Log("index "+ tile.GetLineIndex()+"-"+tile.GetTileIndex()+" Occupy "+ tile.GetOccupyingEnemyUnits().Count);
                if (tile.GetOccupyingEnemyUnits().Count>0)
                {
                    return tile.GetOccupyingEnemyUnits()[0];
                }
            }

            return null;
        }
    }
}