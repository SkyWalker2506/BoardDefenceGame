using UnityEngine;

namespace BoardDefenceGame.MVP.Interface.Unit
{
    public interface IUnitPresenter
    {
        IUnitModel Model { get; }
        void OnPositionChanged(Vector3 position);
        void SetIndex(int lineIndex, int tileIndex);
        int GetLineIndex();
        int GetTileIndex();
    }
}