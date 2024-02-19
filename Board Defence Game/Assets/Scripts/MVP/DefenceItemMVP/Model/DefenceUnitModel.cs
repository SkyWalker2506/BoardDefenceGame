using System;
using Observables;
using UnityEngine;

namespace BoardDefenceGame.MVP.Model
{
    [Serializable]
    public class DefenceUnitModel
    {
        [field:SerializeField] public int Damage { get; private set; }
        [field:SerializeField] public int Range { get; private set; }
        [field:SerializeField] public float Interval { get; private set; }
        [field:SerializeField] public Direction Direction { get; private set; }
        public int TileIndex { get; set; }
        public int LineIndex { get; set; }
        public float LastAttackTime{ get; set; }
        public bool CanAttack => LastAttackTime + Interval <= Time.time;
        public Observable<Vector3> Position{get;} = new();
        
        
    }
    
    public enum Direction
    {
        forward,
        all
    }
}