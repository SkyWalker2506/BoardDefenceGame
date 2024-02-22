using System.Collections.Generic;
using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class TilePresenter : MonoBehaviour
    {
        private TileModel model = new();
        [SerializeField] private TileView view;

        void Awake()
        {
            view.SetTileTransform(transform);
            InitializeTile();
        }

        private void OnEnable()
        {
            model.TilePosition.OnValueChanged += OnTilePositionChanged;
            model.IsTileOccupied.OnValueChanged += OnTileOccupationChanged;
        }

        private void OnDisable()
        {
            model.TilePosition.OnValueChanged -= OnTilePositionChanged;
            model.IsTileOccupied.OnValueChanged -= OnTileOccupationChanged;
        }
        
        void InitializeTile()
        {
            view.SetTileOccupied(false);   
        }
        
        private void OnTileOccupationChanged(bool isOccupied)
        {
            view.SetTileOccupied(isOccupied);
        }
        
        private void OnTilePositionChanged(Vector3 position)
        {
            view.SetTilePosition(position);
        }
        
        public void SetTileIndex(int lineIndex, int tileIndex)
        {
            model.TileIndex = tileIndex;
            model.LineIndex = lineIndex;
        }
        
        public void SetTilePosition(Vector3 position)
        {
            model.TilePosition.Value = position;
        }
        
        public void SetDefenceUnit(DefenceUnitPresenter unit)
        {
            model.OccupyingDefenceUnit = unit;
        }
        
        public bool IsDefenceUnitPlaceable()
        {
            return model.IsDefenceUnitPlaceable && !model.IsTileOccupied.Value;
        }
        
        public void AddEnemyUnit(EnemyUnitPresenter unit)
        {
            model.OccupyingEnemyUnit.Add(unit);
        }
        
        public void RemoveEnemyUnit(EnemyUnitPresenter unit)
        {
            model.OccupyingEnemyUnit.Remove(unit);
        }

        public List<EnemyUnitPresenter> GetOccupyingEnemyUnits()
        {
            return model.OccupyingEnemyUnit;
        }

        public Vector3 GetTilePosition()
        {
            return model.TilePosition.Value;
        }

        public void SetDefencePlaceable(bool isPlaceable)
        {
            model.IsDefenceUnitPlaceable = isPlaceable;
        }

        public int GetLineIndex()
        {
            return model.LineIndex;
        }
        
        public int GetTileIndex()
        {
            return model.TileIndex;
        }
    }    
}