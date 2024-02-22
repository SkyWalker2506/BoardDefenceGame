using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Model;
using UnityEngine;

namespace BoardDefenceGame.UI.MVP.Presenter
{
    public class DefenceUnitPanelPresenter : MonoBehaviour
    {
        private DefenceUnitPanelModel model = new ();
        [SerializeField] private DefenceUnitPanelView view;
        [field:SerializeField] public DefenceUnitButtonPresenter ButtonPrefab { get; private set; }

        private void OnEnable()
        {
            model.UnitButtonData.OnValueChanged += CreateButtons;   
        }

        private void OnDisable()
        {
            model.UnitButtonData.OnValueChanged -= CreateButtons;
        }

        public void InitializePanel(IDefenceUnitPanelData data)
        {
            model.ButtonPrefab.Value = ButtonPrefab;
            model.UnitButtonData.Value=(UnitButtonData[])data.UnitButtonData;
        }

        private void CreateButtons(UnitButtonData[] data)
        {
            if(model.ButtonPrefab.Value == null) return;
            var buttons = model.Buttons;
            foreach (var button in buttons)
            {
                button.OnButtonClicked -= OnButtonClicked;
                Destroy(button.gameObject);
            }
            if (data.Length > buttons.Count)
            {
                for (int i = buttons.Count; i < data.Length; i++)
                {
                    buttons.Add(Instantiate(model.ButtonPrefab.Value, view.PanelTransform));
                }
            }
            else if (data.Length < buttons.Count)
            {
                for (int i = buttons.Count - 1; i >= data.Length; i--)
                {
                    Destroy(buttons[i]);
                    buttons.RemoveAt(i);
                }       
            }
            model.Buttons = buttons;

            for (int i = 0; i < data.Length; i++)
            {
                model.Buttons[i].InitializeButton(data[i]);
                model.Buttons[i].OnButtonClicked += OnButtonClicked;
            }
        }

        private void OnButtonClicked(DefenceUnitButtonPresenter buttonPresenter)
        {
            if (model.SelectedButton.Value == buttonPresenter)
            {
                DeselectAll();
            }
            else
            {
                model.SelectedButton.Value = buttonPresenter;
                foreach (var button in model.Buttons)
                {
                    button.SetIsSelected(button == buttonPresenter);
                }
            }
        }

        public bool IsAnySelected()
        {
            return model.SelectedButton.Value != null;
        }

        public DefenceUnitPresenter GetSelectedDefenceUnit()
        {
            return model.SelectedButton.Value.GetDefenceUnit();
        }

        public void OnSelectedUnitPlaced()
        {
            model.SelectedButton.Value.DecreaseUnitCount();
            DeselectAll();
        }
        
        public void DeselectAll()
        {
            model.SelectedButton = new();
            foreach (var button in model.Buttons)
            {
                button.SetIsSelected(false);
            } 
        }
    }
}