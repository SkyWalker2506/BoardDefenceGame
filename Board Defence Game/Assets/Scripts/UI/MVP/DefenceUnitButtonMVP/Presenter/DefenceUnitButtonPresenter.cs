using System;
using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Model;
using BoardDefenceGame.UI.MVP.View;
using UnityEngine;

namespace BoardDefenceGame.UI.MVP.Presenter
{
    public class DefenceUnitButtonPresenter : MonoBehaviour
    {
        private DefenceUnitButtonModel model = new();
        [SerializeField] private DefenceUnitButtonView view;
        public Action<DefenceUnitButtonPresenter> OnButtonClicked;
            
        private void OnEnable()
        {
            model.UnitName.OnValueChanged += OnUnitNameChanged;
            model.UnitCount.OnValueChanged += OnUnitCountChanged;
            model.IsSelected.OnValueChanged += OnIsSelectedChanged;
            view.UnitButton.onClick.AddListener(()=>OnButtonClicked?.Invoke(this));
        }
        
        private void OnDisable()
        {
            model.UnitName.OnValueChanged -= OnUnitNameChanged;
            model.UnitCount.OnValueChanged -= OnUnitCountChanged;
            model.IsSelected.OnValueChanged -= OnIsSelectedChanged;
            view.UnitButton.onClick.RemoveListener(()=>OnButtonClicked?.Invoke(this));
        }
        
        public void InitializeButton(IUnitButtonData data)
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
            view.SetActive(unitCount > 0);
        }
        
        private void OnIsSelectedChanged(bool isSelected)
        {
            view.SetIsSelected(isSelected);
        }

        public void SetIsSelected(bool isSelected)
        {
            model.IsSelected.Value = isSelected;
        }

        public DefenceUnitPresenter GetDefenceUnit()
        {
            return model.DefenceUnit;
        }

        public void DecreaseUnitCount()
        {
            model.UnitCount.Value--;
        }
    }
}