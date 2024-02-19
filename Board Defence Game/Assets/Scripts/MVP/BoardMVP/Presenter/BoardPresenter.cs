using System;
using System.Collections.Generic;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class BoardPresenter : MonoBehaviour
    {
        [SerializeField] private BoardView view;
        private BoardModel model = new();
        [SerializeField] private LinePresenter linePrefab;
        
        void Awake()
        {
            view.SetBoardTransform(transform);
        }
        
        private void OnEnable()
        {
            model.TileCount.OnValueChanged += OnTileCountChanged;
            model.TileOffset.OnValueChanged += OnTileOffsetChanged;
            model.LineCount.OnValueChanged += OnLineCountChanged;
            model.BoardPosition.OnValueChanged += OnBoardPositionChanged;
            model.LineOffset.OnValueChanged += OnLineOffsetChanged;
            model.LineLocalPositions.OnValueChanged += OnLinePositionsChanged;
        }
        private void OnDisable()
        {
            model.TileCount.OnValueChanged -= OnTileCountChanged;
            model.TileOffset.OnValueChanged -= OnTileOffsetChanged;
            model.LineCount.OnValueChanged -= OnLineCountChanged;
            model.BoardPosition.OnValueChanged -= OnBoardPositionChanged;
            model.LineOffset.OnValueChanged -= OnLineOffsetChanged;
            model.LineLocalPositions.OnValueChanged -= OnLinePositionsChanged;
        }

        public void InitializeBoard(IBoardData data)
        {
            model.BoardPosition.Value = data.BoardPosition;
            model.LineOffset.Value = data.LineOffset;
            model.LineCount.Value = data.LineCount;
            model.TileOffset.Value = data.TileOffset;
            model.TileCount.Value = data.TileCount;
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
            for (int i = 0; i < positions.Count; i++)
            {
                view.UpdateLinePosition(model.Lines[i], positions[i]);
            }
        }
        
        private void CreateLines(int tileCount)
        {
            if(linePrefab == null) return;
            var lines = model.Lines;
            if (tileCount > lines.Count)
            {
                for (int i = 0; i < tileCount; i++)
                {
                    lines.Add(Instantiate(linePrefab, view.BoardTransform));
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

        
    }
}