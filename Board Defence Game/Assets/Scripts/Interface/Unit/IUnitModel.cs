using Observables;
using UnityEngine;

namespace Interface.Unit
{
    public interface IUnitModel
    {
        int LineIndex { get; set; }
        int TileIndex { get; set; }
        Observable<Vector3> Position{get;}
    }
}