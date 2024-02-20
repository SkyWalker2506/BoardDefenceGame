using BoardDefenceGame.MVP.Presenter;

namespace BoardDefenceGame.UI.MVP.Model
{
    public interface IUnitButtonData
    {
        DefenceUnitPresenter DefenceUnit { get; }
        int UnitCount { get; }
        string UnitName { get; }
    }
}