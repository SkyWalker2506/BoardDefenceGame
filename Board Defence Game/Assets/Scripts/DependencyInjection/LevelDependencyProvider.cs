using BoardDefenceGame.Managers;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.DependencyInjection
{
    public class LevelDependencyProvider : MonoBehaviour, IDependencyProvider
    {
        [SerializeField] private ScriptableBoardData boardData;
        
        [Provide] private LevelManager ProvideLevelManager() => FindObjectOfType<LevelManager>();
        [Provide] private BoardPresenter ProvideBoardPresenter() => FindObjectOfType<BoardPresenter>();
        [Provide] private IBoardData ProvideBoard() => boardData;

        
    }
}