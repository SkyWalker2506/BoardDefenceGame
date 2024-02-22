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


        private void OnEnable()
        {
            model.TilePrefab.OnValueChanged += OnTilePrefabChanged;
            model.TileCount.OnValueChanged += OnTileCountChanged;
            model.MaxDefencePlaceableTileIndex.OnValueChanged += OnMaxDefencePlaceableTileIndexChanged;
            model.LinePosition.OnValueChanged += OnLinePositionChanged;
            model.TileOffset.OnValueChanged += OnTileOffsetChanged;
            model.TileLocalPositions.OnValueChanged += OnTilePositionsChanged;
        }


        private void OnDisable()
        {
            model.TilePrefab.OnValueChanged -= OnTilePrefabChanged;
            model.TileCount.OnValueChanged -= OnTileCountChanged;
            model.MaxDefencePlaceableTileIndex.OnValueChanged -= OnMaxDefencePlaceableTileIndexChanged;
            model.LinePosition.OnValueChanged -= OnLinePositionChanged;
            model.TileOffset.OnValueChanged -= OnTileOffsetChanged;
            model.TileLocalPositions.OnValueChanged -= OnTilePositionsChanged;
        }

        private void OnTilePrefabChanged(TilePresenter tilePrefab)
        {
            foreach (var tile in model.Tiles)
            {
                Destroy(tile.gameObject);
            }
            model.Tiles.Clear();
            CreateTiles(model.TileCount.Value);
        }
        
        private void OnTileCountChanged(int tileCount)
        {
            CreateTiles(tileCount);
            model.UpdateTilePositions();
        }
        
        private void OnMaxDefencePlaceableTileIndexChanged(int maxTileIndex)
        {
            for (int i = 0; i < model.TileCount.Value; i++)
            {
                model.Tiles[i].SetDefencePlaceable(i < maxTileIndex);
            }
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
            for (int i = 0; i < model.Tiles.Count; i++)
            {
                view.SetTilePosition(model.Tiles[i], positions[i]);
            }
        }
        
        public void SetTilePrefab(TilePresenter tilePresenter)
        {
            model.TilePrefab.Value = tilePresenter;
        }
        
        public void SetTileCount(int count)
        {
            model.TileCount.Value = count;
        }

        public void SetLineIndex(int index)
        {
            model.LineIndex = index;
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
            if(model.TilePrefab.Value == null) return;
            var tiles = model.Tiles;
            if (tileCount > tiles.Count)
            {
                for (int i = 0; i < tileCount; i++)
                {
                    var tile = Instantiate(model.TilePrefab.Value, view.LineTransform);
                    tile.SetTileIndex(model.LineIndex, i);
                    tiles.Add(tile);
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

        public void SetMaxDefencePlaceableTileIndex(int maxTileIndex)
        {
            model.MaxDefencePlaceableTileIndex.Value = maxTileIndex;
        }

        public TilePresenter GetLastTile()
        {
            return model.Tiles[model.TileCount.Value-1];
        }
    }
}