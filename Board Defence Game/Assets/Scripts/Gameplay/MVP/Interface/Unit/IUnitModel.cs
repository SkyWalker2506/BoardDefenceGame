using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Interface.Unit
{
    public interface IUnitModel
    {
        int LineIndex { get; set; }
        int TileIndex { get; set; }
        Observable<Vector3> Position{get;}
    }
}