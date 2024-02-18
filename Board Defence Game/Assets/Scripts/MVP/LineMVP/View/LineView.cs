using System.Collections.Generic;
using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.MVP.View
{
    public class LineView : MonoBehaviour
    {
        [SerializeField] private TilePresenter tilePrefab;
        private Transform lineTransform;
        private List<TilePresenter> tiles = new(); 
        
        public void SetLineTransform(Transform tr)
        {
            lineTransform = tr;
        }
        
        public void CreateTiles(int tileCount)
        {
            if(tilePrefab == null) return;
            
            if (tileCount > tiles.Count)
            {
                for (int i = 0; i < tileCount; i++)
                {
                    tiles.Add(Instantiate(tilePrefab, lineTransform));
                }
            }
            else if (tileCount < tiles.Count)
            {
                for (int i = tiles.Count - 1; i >= tileCount; i--)
                {
                    Destroy(tiles[i]);
                    tiles.RemoveAt(i);
                }       
            }
        }

        public void SetLinePosition(Vector3 linePosition)
        {
            lineTransform.localPosition = linePosition;
        }
        
        public void UpdateTilePositions(Vector3[] tilePositions)
        {
            for (int i = 0; i < tilePositions.Length; i++)
            {
                tiles[i].SetTilePosition(tilePositions[i]);
            }
        }
    }
}