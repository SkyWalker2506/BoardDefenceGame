using System.Collections.Generic;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public class LineModel
    {
        public Observable<int> TileCount { get; } = new();
        public Observable<Vector3> LinePosition{get;} = new();
        public Observable<Vector3> TileOffset { get; } = new();
        public Observable<List<Vector3>> TileLocalPositions { get; } = new();
        
        
        public void UpdateTilePositions()
        {
            List<Vector3> tilePositions = new List<Vector3>();
            for (int i = 0; i < TileCount.Value; i++)
            {
                tilePositions.Add(TileOffset.Value * i);
            }
            TileLocalPositions.Value = tilePositions;
        }
        
        
        
    }
}