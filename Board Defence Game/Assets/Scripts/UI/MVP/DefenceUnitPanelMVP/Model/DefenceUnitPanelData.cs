using UnityEngine;

namespace BoardDefenceGame.UI.MVP.Model
{
    [CreateAssetMenu(fileName = "DefenceUnitPanelData", menuName = "BoardDefenceGame/DefenceUnitPanelData", order = 1)]
    public class ScriptableDefenceUnitPanelData : ScriptableObject , IDefenceUnitPanelData
    {
        [SerializeField] public UnitButtonData[] unitButtonData;
        public IUnitButtonData[] UnitButtonData => unitButtonData;

    }
}