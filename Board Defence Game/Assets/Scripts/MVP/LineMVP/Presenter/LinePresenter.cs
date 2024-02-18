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
            view.CreateTiles(tileCount);
            model.UpdateTilePositions();
        }
        
        private void OnLinePositionChanged(Vector3 linePosition)
        {
            view.SetLinePosition(linePosition);
        }
        private void OnTileOffsetChanged(Vector3 obj)
        {
            model.UpdateTilePositions();
        }




        
        private void OnTilePositionsChanged(List<Vector3> positions)
        {
            view.UpdateTilePositions(positions.ToArray());
        }
    }
}