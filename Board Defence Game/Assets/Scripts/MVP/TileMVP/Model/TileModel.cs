using System.Collections.Generic;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public class TileModel 
    {
        public int TileIndex;
        public Observable<Vector3> Position{get;} = new();
        public Observable<bool> IsTileOccupied {get;} = new();
        
        List<GameObject> occupyingUnits = new();
        public List<GameObject> OccupyingUnits
        {
            get => occupyingUnits;
            set
            {
                occupyingUnits = value;
                IsTileOccupied.Value = occupyingUnits.Count > 0;
            }
        } 
    }
}
