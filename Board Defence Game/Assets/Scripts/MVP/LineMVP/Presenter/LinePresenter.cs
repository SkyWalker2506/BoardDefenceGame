using System.Collections.Generic;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class LinePresenter : MonoBehaviour
    {
        [SerializeField] private LineView view;
        private LineModel model = new();
        [SerializeField] private TilePresenter tilePrefab;

        void Awake()
        {
            view.SetLineTransform(transform);
        }

        private void OnEnable()
        {
            model.TileCount.OnValueChanged += OnTileCountChanged;
            model.LinePosition.OnValueChanged += OnLinePositionChanged;
            model.TileOffset.OnValueChanged += OnTileOffsetChanged;
            model.TileLocalPositions.OnValueChanged += OnTilePositionsChanged;
        }

        private void OnDisable()
        {
            model.TileCount.OnValueChanged -= OnTileCountChanged;
            model.LinePosition.OnValueChanged -= OnLinePositionChanged;
            model.TileOffset.OnValueChanged -= OnTileOffsetChanged;
            model.TileLocalPositions.OnValueChanged -= OnTilePositionsChanged;
        }

        private void OnTileCountChanged(int tileCount)
        {
            CreateTiles(tileCount);
            model.UpdateTilePositions();
        }
        private void OnLinePositionChanged(Vector3 linePosition)
        {
            view.SetLinePosition(linePosition);
        }
        private void OnTileOffsetChanged(Vector3 tileOffset)
        {
            model.UpdateTilePositions();
        }
        private void OnTilePositionsChanged(List<Vector3> positions)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                view.SetTilePosition(model.Tiles[i], positions[i]);
            }
        }
        
        public void SetTileCount(int count)
        {
            model.TileCount.Value = count;
        }
        
        public void SetLinePosition(Vector3 position)
        {
            model.LinePosition.Value = position;
        }

        public void SetTileOffset(Vector3 tileOffset)
        {
            model.TileOffset.Value = tileOffset;
        }
        
        private void CreateTiles(int tileCount)
        {
            if(tilePrefab == null) return;
            var tiles = model.Tiles;
            if (tileCount > tiles.Count)
            {
                for (int i = 0; i < tileCount; i++)
                {
                    tiles.Add(Instantiate(tilePrefab, view.LineTransform));
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
            model.Tiles = tiles;
        }
        
    }
}