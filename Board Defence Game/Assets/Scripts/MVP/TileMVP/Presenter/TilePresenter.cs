using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class TilePresenter : MonoBehaviour
    {
        [SerializeField] private TileView view;
        private TileModel model;

        private void Awake()
        {
            model = new TileModel();
        }
        
        void Start()
        {
            view.SetTileTransform(transform);
        }

        private void OnEnable()
        {
            model.IsTileOccupied.OnValueChanged += OnTileOccupationChanged;
            model.Position.OnValueChanged += OnTilePositionChanged;
        }

        private void OnDisable()
        {
            model.IsTileOccupied.OnValueChanged -= OnTileOccupationChanged;
            model.Position.OnValueChanged -= OnTilePositionChanged;
        }
        
        private void OnTileOccupationChanged(bool isOccupied)
        {
            view.SetTileOccupied(isOccupied);
        }
        
        private void OnTilePositionChanged(Vector3 position)
        {
            view.SetTilePosition(position);
        }
        
        public void SetTileIndex(int index)
        {
            model.TileIndex = index;
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
            model.Position.Value = position;
        }
        
    }    
}