using UnityEngine;

namespace BoardDefenceGame.MVP.View
{
    public class DefenceUnitView : MonoBehaviour
    {
        private Transform itemTransform;
        
        public void SetTileTransform(Transform tr)
        {
            itemTransform = tr;
        }

        public void SetTilePosition(Vector3 position)
        {
            itemTransform.position = position;
        }
    }
}