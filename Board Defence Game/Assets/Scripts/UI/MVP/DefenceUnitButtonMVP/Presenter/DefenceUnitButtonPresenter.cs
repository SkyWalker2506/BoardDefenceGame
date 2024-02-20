using BoardDefenceGame.UI.MVP.Model;
using BoardDefenceGame.UI.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.UI.MVP.Presenter
{
    public class DefenceUnitButtonPresenter : MonoBehaviour
    {
        private DefenceUnitButtonModel model = new();
        [SerializeField] private DefenceUnitButtonView view;

        private void OnEnable()
        {
            model.UnitName.OnValueChanged += OnUnitNameChanged;
            model.UnitCount.OnValueChanged += OnUnitCountChanged;
            model.IsSelected.OnValueChanged += OnIsSelectedChanged;
        }
        
        private void OnDisable()
        {
            model.UnitName.OnValueChanged -= OnUnitNameChanged;
            model.UnitCount.OnValueChanged -= OnUnitCountChanged;
            model.IsSelected.OnValueChanged -= OnIsSelectedChanged;
        }
        
        public void InitializeBoard(IUnitButtonData data)
        {
            model.DefenceUnit = data.DefenceUnit;
            model.UnitCount.Value = data.UnitCount;
            model.UnitName.Value = data.UnitName;
        }

        private void OnUnitNameChanged(string unitName)
        {
            view.SetUnitName(unitName);
        }
        
        private void OnUnitCountChanged(int unitCount)
        {
            view.SetUnitCount(unitCount);
        }
        
        private void OnIsSelectedChanged(bool isSelected)
        {
            view.SetIsSelected(isSelected);
        }
    }
}