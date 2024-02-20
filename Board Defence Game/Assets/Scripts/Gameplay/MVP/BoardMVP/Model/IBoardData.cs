using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    public interface IBoardData
    {
        LinePresenter LinePrefab { get; }
        TilePresenter TilePrefab { get; }
        Vector3 BoardPosition { get;  }
        Vector3 LineOffset { get;  }
        int LineCount { get;  }
        Vector3 TileOffset { get; }
        int TileCount { get; }
    }
}