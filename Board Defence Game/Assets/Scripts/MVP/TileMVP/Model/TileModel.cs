using System.Collections.Generic;
using BoardDefenceGame.MVP.Presenter;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public class TileModel 
    {
        public Observable<Vector3> TilePosition{get;} = new();
        public Observable<bool> IsTileOccupied {get;} = new();
        
        DefenceUnitPresenter occupyingDefenceDefenceUnit;
        public DefenceUnitPresenter OccupyingDefenceUnit
        {
            get => occupyingDefenceDefenceUnit;
            set
            {
                occupyingDefenceDefenceUnit = value;
                IsTileOccupied.Value = occupyingDefenceDefenceUnit != null;
            }
        }
        public List<EnemyUnitPresenter> OccupyingEnemyUnit { get; } = new();

    }
}
