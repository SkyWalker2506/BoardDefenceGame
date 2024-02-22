using UnityEngine;

namespace BoardDefenceGame.MVP.Interface.Unit
{
    public interface IUnitView
    {
        Transform UnitTransform { get; }

        void SetUnitTransform(Transform tr);

        void SetUnitPosition(Vector3 position);
    }
}