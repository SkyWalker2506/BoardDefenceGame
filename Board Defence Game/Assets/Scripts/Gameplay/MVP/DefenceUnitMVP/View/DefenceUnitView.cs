using UnityEngine;
using Interface.Unit;

namespace BoardDefenceGame.MVP.View
{
    public class DefenceUnitView : MonoBehaviour, IUnitView
    {
        public Transform UnitTransform { get;private set;}

        public void SetUnitTransform(Transform tr)
        {
            UnitTransform = tr;
        }

        public void SetUnitPosition(Vector3 position)
        {
            UnitTransform.position = position;
        }
    }
}