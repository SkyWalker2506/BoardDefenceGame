using System;
using BoardDefenceGame.MVP.Interface.Unit;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    [Serializable]
    public class EnemyUnitModel : IUnitModel
    {
        [field:SerializeField] public float Health { get; private set; }
        [field:SerializeField] public float Speed { get; private set; }
        
        public int TileIndex { get; set; }
        public int LineIndex { get; set; }
        public Observable<Vector3> Position{get;} = new();

    }
}