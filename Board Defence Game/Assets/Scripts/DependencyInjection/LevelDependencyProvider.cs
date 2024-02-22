using BoardDefenceGame.Data;
using BoardDefenceGame.Manager;
using BoardDefenceGame.MVP.Interface.Model;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.DependencyInjection
{
    public class LevelDependencyProvider : MonoBehaviour, IDependencyProvider
    {
        [SerializeField] private ScriptableBoardData boardData;
        [SerializeField] private LevelData[] levelData;

        [Provide] private LevelManager ProvideLevelManager() => FindObjectOfType<LevelManager>();
        [Provide] private BoardPresenter ProvideBoardPresenter() => FindObjectOfType<BoardPresenter>();
        [Provide] private DefenceUnitPanelPresenter ProvideDefenceUnitPanelPresenter() => FindObjectOfType<DefenceUnitPanelPresenter>();
        [Provide] private EnemyUnitManager ProvideEnemyUnitManager() => FindObjectOfType<EnemyUnitManager>();
        [Provide] private IBoardData ProvideBoard() => boardData;
        [Provide] private LevelData[] ProvideLevelData() => levelData;
    }
}