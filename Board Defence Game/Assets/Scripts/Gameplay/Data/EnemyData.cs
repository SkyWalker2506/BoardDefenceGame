using System;
using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.Data
{
    [Serializable]
    public struct EnemyData : IEnemyData
    {
        [field:SerializeField] public EnemyUnitPresenter EnemyUnitPrefab { get; private set; }
        [field:SerializeField] public int EnemyUnitCount { get; set;}
    }
}