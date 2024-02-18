using System.Collections.Generic;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public class TileModel 
    {
        public int TileIndex;
        public Observable<bool> IsTileOccupied {get;} = new Observable<bool>();
        public Observable<Vector3> Position{get;} = new Observable<Vector3>();
        
        List<GameObject> occupyingUnits = new List<GameObject>();
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
