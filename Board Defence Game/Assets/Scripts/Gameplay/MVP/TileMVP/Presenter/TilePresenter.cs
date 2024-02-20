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
        
        private void OnTileOccupationChanged(bool isOccupied)
        {
            view.SetTileOccupied(isOccupied);
        }
        
        private void OnTilePositionChanged(Vector3 position)
        {
            view.SetTilePosition(position);
        }
        
        void InitializeTile()
        {
            view.SetTileOccupied(false);   
        }
        
        public void SetTilePosition(Vector3 position)
        {
            model.TilePosition.Value = position;
        }
        
        public void SetDefenceUnit(DefenceUnitPresenter unit)
        {
            model.OccupyingDefenceUnit = unit;
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
    }    
}