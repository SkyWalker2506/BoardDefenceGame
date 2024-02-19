using BoardDefenceGame.MVP.Model;
using Interface.Unit;
using UnityEngine;

namespace BoardDefenceGame.MVP.Presenter
{
    public class EnemyUnitPresenter : MonoBehaviour, IUnitPresenter
    {
        [SerializeField]  private EnemyUnitModel model;
        [SerializeField] private EnemyUnitView view;
        public IUnitModel Model => model;

        
        private void OnEnable()
        {
            model.Position.OnValueChanged += OnPositionChanged;
        }

        private void OnDisable()
        {
            model.Position.OnValueChanged -= OnPositionChanged;
        }

        public void OnPositionChanged(Vector3 position)
        {
            view.SetUnitPosition(position);
        }

        public void SetIndex(int lineIndex, int tileIndex)
        {
            model.LineIndex = lineIndex;
            model.TileIndex = tileIndex;    
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