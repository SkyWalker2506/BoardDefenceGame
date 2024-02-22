using BoardDefenceGame.MVP.Presenter;

namespace BoardDefenceGame.Data
{
    public interface IEnemyData
    {
        EnemyUnitPresenter EnemyUnitPrefab { get; }
        int EnemyUnitCount { get; set; }
    }
}