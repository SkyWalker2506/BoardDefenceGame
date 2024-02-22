using BoardDefenceGame.Manager;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Model;
using BoardDefenceGame.UI.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.DependencyInjection
{
    public class LevelDependencyProvider : MonoBehaviour, IDependencyProvider
    {
        [SerializeField] private ScriptableBoardData boardData;
        [SerializeField] private ScriptableDefenceUnitPanelData defenceUnitPanelData;
        
        [Provide] private LevelManager ProvideLevelManager() => FindObjectOfType<LevelManager>();
        [Provide] private BoardPresenter ProvideBoardPresenter() => FindObjectOfType<BoardPresenter>();
        [Provide] private IBoardData ProvideBoard() => boardData;
        [Provide] private DefenceUnitPanelPresenter ProvideDefenceUnitPanelPresenter() => FindObjectOfType<DefenceUnitPanelPresenter>();
        [Provide] private IDefenceUnitPanelData ProvideDefenceUnitPanelData() => defenceUnitPanelData;

    }
}