using BoardDefenceGame.UI.MVP.Model;
using UnityEngine;

namespace BoardDefenceGame.UI.MVP.Presenter
{
    public class DefenceUnitPanelPresenter : MonoBehaviour
    {
        private DefenceUnitPanelModel model;
        [SerializeField] private DefenceUnitPanelView view;
        
        public void InitializePanel(IDefenceUnitPanelData data)
        {
        }

        public void CreateButtons(int buttonCount)
        {
            if(model.ButtonPrefab.Value == null) return;
            var buttons = model.Buttons;
            if (buttonCount > buttons.Count)
            {
                for (int i = 0; i < buttonCount; i++)
                {
                    buttons.Add(Instantiate(model.ButtonPrefab.Value, view.PanelTransform));
                }
            }
            else if (buttonCount < buttons.Count)
            {
                for (int i = buttons.Count - 1; i >= buttonCount; i--)
                {
                    Destroy(buttons[i]);
                    buttons.RemoveAt(i);
                }       
            }
            model.Buttons = buttons;
        }

    }
}