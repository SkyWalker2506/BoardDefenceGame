using System.Collections.Generic;
using BoardDefenceGame.MVP.Presenter;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public class BoardModel
    {
        public Observable<LinePresenter> LinePrefab { get; } = new();
        public Observable<TilePresenter> TilePrefab { get; } = new();
        public Observable<int> TileCount { get; } = new();
        public Observable<Vector3> TileOffset { get; } = new();
        public Observable<int> LineCount { get; } = new();
        public Observable<Vector3> BoardPosition{get;} = new();
        public Observable<Vector3> LineOffset { get; } = new();
        public List<LinePresenter> Lines { get; set; } = new();
        public Observable<List<Vector3>> LineLocalPositions { get; } = new();

        public void UpdateLinePositions()
        {
            List<Vector3> linePositions = new List<Vector3>();
            for (int i = 0; i < LineCount.Value; i++)
            {
                linePositions.Add(LineOffset.Value * i);
            }
            LineLocalPositions.Value = linePositions;
        }
    }
}