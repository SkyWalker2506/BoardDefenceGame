using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.Presenter;
using DependencyInjection;
using UnityEngine;


namespace BoardDefenceGame.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [Inject] private BoardPresenter boardPresenter;
        [Inject] private IBoardData boardData;
        
        public void InitializeLevel()
        {
            boardPresenter.InitializeBoard(boardData);
        }
            
    }
}
