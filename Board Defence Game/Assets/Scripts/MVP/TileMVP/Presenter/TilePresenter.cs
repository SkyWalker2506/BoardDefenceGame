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
            model.IsTileOccupied.OnValueChanged += OnTileOccupationChanged;
            model.TilePosition.OnValueChanged += OnTilePositionChanged;
        }

        private void OnDisable()
        {
            model.IsTileOccupied.OnValueChanged -= OnTileOccupationChanged;
            model.TilePosition.OnValueChanged -= OnTilePositionChanged;
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
        
        public void AddUnit(GameObject unit)
        {
            model.OccupyingUnits.Add(unit);
        }
        
        public void RemoveUnit(GameObject unit)
        {
            model.OccupyingUnits.Remove(unit);
        }
        
        public void SetTilePosition(Vector3 position)
        {
            model.TilePosition.Value = position;
        }

        
    }    
}