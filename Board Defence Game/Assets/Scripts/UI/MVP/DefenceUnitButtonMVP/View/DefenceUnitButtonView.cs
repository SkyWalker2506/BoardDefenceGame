using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BoardDefenceGame.UI.MVP.View
{
    public class DefenceUnitButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text unitNameText;
        [SerializeField] private TMP_Text unitCountText;
        [SerializeField] private GameObject selectedIndicator;
        public Button UnitButton;

        public void SetUnitName(string unitName)
        {
            unitNameText.SetText(unitName);
        }
        public void SetUnitCount(int unitCount)
        {
            unitCountText.SetText(unitCount.ToString());
        }

        public void SetIsSelected(bool isSelected)
        {
            selectedIndicator.SetActive(isSelected);
        }
        
        public void SetActive(bool isActive)
        {
            UnitButton.interactable = isActive;
        }
    }
}