using BoardDefenceGame.MVP.Model;
using BoardDefenceGame.MVP.View;
using UnityEngine;


namespace BoardDefenceGame.MVP.Presenter
{
    public class DefenceUnitPresenter : MonoBehaviour
    {
        [SerializeField] private DefenceUnitModel model;
        [SerializeField] private DefenceUnitView view;

        void Awake()
        {
            view.SetTileTransform(transform);
        }

        private void OnEnable()
        {
            model.Position.OnValueChanged += OnPositionChanged;
        }

        private void OnDisable()
        {
            model.Position.OnValueChanged -= OnPositionChanged;
        }

        private void OnPositionChanged(Vector3 position)
        {
            view.SetTilePosition(position);
        }
        
        public void SetPosition(Vector3 position)
        {
            model.Position.Value = position;
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
        
        public bool TryAttack()
        {
            if (model.CanAttack)
            {
                model.LastAttackTime = Time.time;
                return true;
            }
            return false;
        }

    }
}
