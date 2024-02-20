using BoardDefenceGame.MVP.Presenter;
using Observables;

namespace BoardDefenceGame.UI.MVP.Model
{
    public class DefenceUnitButtonModel
    {
        public DefenceUnitPresenter DefenceUnit { get; set; } 
        public Observable<int> UnitCount { get; } = new();
        public Observable<string> UnitName { get; } = new();
        public Observable<bool> IsSelected { get; } = new();
    }
}