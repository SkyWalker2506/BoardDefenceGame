using UnityEngine;

namespace Interface.Unit
{
    public interface IUnitView
    {
        Transform UnitTransform { get; }

        void SetUnitTransform(Transform tr);

        void SetUnitPosition(Vector3 position);
    }
}