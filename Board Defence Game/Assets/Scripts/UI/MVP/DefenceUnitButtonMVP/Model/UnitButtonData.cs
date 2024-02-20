using System;
using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.UI.MVP.Model
{
    [Serializable]
    public class UnitButtonData: IUnitButtonData
    {
        [field:SerializeField] public DefenceUnitPresenter DefenceUnit { get; private set; }
        [field:SerializeField] public int UnitCount { get; private set;}
        [field:SerializeField] public string UnitName { get; private set; }
    }
}