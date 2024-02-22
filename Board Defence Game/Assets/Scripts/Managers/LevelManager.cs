using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Model;
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
        [Inject] private IDefenceUnitPanelData defenceUnitPanelData;
        public void InitializeLevel()
        {
            boardPresenter.InitializeBoard(boardData);
            defenceUnitPanelPresenter.InitializePanel(defenceUnitPanelData);
        }
            
    }
}
