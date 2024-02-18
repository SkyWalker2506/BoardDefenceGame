using UnityEngine;

namespace  BoardDefenceGame.MVP.View
{
    public class TileView : MonoBehaviour
    {
        private Transform tileTransform;
        [SerializeField] Renderer tileRenderer;
        [SerializeField] Color occupiedColor;
        [SerializeField] Color unoccupiedColor;
        
        public void SetTileTransform(Transform tr)
        {
            tileTransform = tr;
        }
        
        public void SetTileOccupied(bool isOccupied)
        {
            tileRenderer.material.color = isOccupied ? occupiedColor : unoccupiedColor;
        }

        public void SetTilePosition(Vector3 position)
        {
            tileTransform.position = position;
        }


    }
}
