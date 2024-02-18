using System.Collections.Generic;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public class TileModel 
    {
        public int TileIndex;
        public Observable<Vector3> Position{get;} = default;
        public Observable<bool> IsTileOccupied {get;} = default;
        
        List<GameObject> occupyingUnits = default;
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
