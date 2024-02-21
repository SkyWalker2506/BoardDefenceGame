using System.Collections.Generic;
using BoardDefenceGame.UI.MVP.Presenter;
using Observables;

namespace BoardDefenceGame.UI.MVP.Model
{
    public class DefenceUnitPanelModel
    {
        public Observable<DefenceUnitButtonPresenter> ButtonPrefab { get; } = new();
        public Observable<UnitButtonData[]> UnitButtonData { get; } = new();
        public List<DefenceUnitButtonPresenter> Buttons { get; set; } = new();
        public Observable<DefenceUnitButtonPresenter> SelectedButton { get; set; } = new();
    }
}
