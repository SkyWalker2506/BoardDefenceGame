using BoardDefenceGame.Data;
using BoardDefenceGame.MVP.Interface.Model;
using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    public class LevelManager : MonoBehaviour
    {
        [Inject] private BoardPresenter boardPresenter;
        [Inject] private IBoardData boardData;
        [Inject] private DefenceUnitPanelPresenter defenceUnitPanelPresenter;
        [Inject] private LevelData[] levelData;
        [Inject] private EnemyUnitManager enemyUnitManager;
        
        public void InitializeLevel(int level)
        {
            boardPresenter.InitializeBoard(boardData);
            defenceUnitPanelPresenter.InitializePanel(levelData[level-1].DefenceUnitData);
            enemyUnitManager.InitializeEnemyUnits(levelData[level-1].EnemyUnitData.GetEnemyData());
        }
            
    }
}
