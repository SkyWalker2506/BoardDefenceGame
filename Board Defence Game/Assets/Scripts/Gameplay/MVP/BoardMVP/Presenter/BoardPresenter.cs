using System.Collections.Generic;
using BoardDefenceGame.MVP.Interface.Model;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class BoardPresenter : MonoBehaviour
    {
        [SerializeField] private BoardView view;
        private BoardModel model = new();

        private void OnEnable()
        {
            model.LinePrefab.OnValueChanged += OnLinePrefabChanged;
            model.TilePrefab.OnValueChanged += OnTilePrefabChanged;
            model.MaxDefencePlaceableTileIndex.OnValueChanged += OnMaxDefencePlaceableTileIndexChanged;
            model.TileCount.OnValueChanged += OnTileCountChanged;
            model.TileOffset.OnValueChanged += OnTileOffsetChanged;
            model.LineCount.OnValueChanged += OnLineCountChanged;
            model.BoardPosition.OnValueChanged += OnBoardPositionChanged;
            model.LineOffset.OnValueChanged += OnLineOffsetChanged;
            model.LineLocalPositions.OnValueChanged += OnLinePositionsChanged;
        }

        private void OnDisable()
        {
            model.LinePrefab.OnValueChanged -= OnLinePrefabChanged;
            model.TilePrefab.OnValueChanged -= OnTilePrefabChanged;
            model.MaxDefencePlaceableTileIndex.OnValueChanged -= OnMaxDefencePlaceableTileIndexChanged;
            model.TileCount.OnValueChanged -= OnTileCountChanged;
            model.TileOffset.OnValueChanged -= OnTileOffsetChanged;
            model.LineCount.OnValueChanged -= OnLineCountChanged;
            model.BoardPosition.OnValueChanged -= OnBoardPositionChanged;
            model.LineOffset.OnValueChanged -= OnLineOffsetChanged;
            model.LineLocalPositions.OnValueChanged -= OnLinePositionsChanged;
        }
        
        public void InitializeBoard(IBoardData data)
        {
            model.TilePrefab.Value = data.TilePrefab;
            model.LinePrefab.Value = data.LinePrefab;
            model.BoardPosition.Value = data.BoardPosition;
            model.LineOffset.Value = data.LineOffset;
            model.LineCount.Value = data.LineCount;
            model.TileOffset.Value = data.TileOffset;
            model.TileCount.Value = data.TileCount;
            model.MaxDefencePlaceableTileIndex.Value = data.MaxDefencePlaceableTileIndex;
        }
        
        private void OnLinePrefabChanged(LinePresenter linePrefab)
        {
            foreach (var line in model.Lines)
            {
                Destroy(line.gameObject);
            }
            model.Lines.Clear();
            CreateLines(model.LineCount.Value);
        }
        
        private void OnTilePrefabChanged(TilePresenter tilePrefab)
        {
            foreach (var line in model.Lines)
            {
                line.SetTilePrefab(tilePrefab);
            }
        }
        
        private void OnMaxDefencePlaceableTileIndexChanged(int maxTileIndex)
        {
            foreach (var line in model.Lines)
            {
                line.SetMaxDefencePlaceableTileIndex(maxTileIndex);
            }
        }
        
        private void OnTileCountChanged(int tileCount)
        {
            foreach (var line in model.Lines)
            {
                line.SetTileCount(tileCount);
            }
        }

        private void OnTileOffsetChanged(Vector3 obj)
        {
            foreach (var line in model.Lines)
            {
                line.SetTileOffset(obj);
            }
        }

        private void OnLineCountChanged(int count)
        {
            CreateLines(count);
            model.UpdateLinePositions();
        }
        
        private void OnBoardPositionChanged(Vector3 boardPosition)
        {
            view.SetBoardPosition(boardPosition);
        }
        
        private void OnLineOffsetChanged(Vector3 offset)
        {
            model.UpdateLinePositions();
        }
        
        private void OnLinePositionsChanged(List<Vector3> positions)
        {
            for (int i = 0; i < model.Lines.Count; i++)
            {
                view.UpdateLinePosition(model.Lines[i], positions[i]);
            }
        }
        
        private void CreateLines(int tileCount)
        {
            if(model.LinePrefab.Value == null) return;
            var lines = model.Lines;
            if (tileCount > lines.Count)
            {
                for (int i = 0; i < tileCount; i++)
                {
                    var line = Instantiate(model.LinePrefab.Value, view.BoardTransform);
                    line.SetLineIndex(i);
                    lines.Add(line);
                    lines[i].SetTilePrefab(model.TilePrefab.Value);
                }
            }
            else if (tileCount < lines.Count)
            {
                for (int i = lines.Count - 1; i >= tileCount; i--)
                {
                    Destroy(lines[i]);
                    lines.RemoveAt(i);
                }       
            }
            model.Lines = lines;
        }

        public LinePresenter GetRandomLine()
        {
            int index = Random.Range(0, model.Lines.Count);
            return model.Lines[index];
        }

        public LinePresenter GetLine(int lineIndex)
        {
            return model.Lines[lineIndex];
        }
    }
}