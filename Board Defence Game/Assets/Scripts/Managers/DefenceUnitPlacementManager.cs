using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    public class DefenceUnitPlacementManager : MonoBehaviour
    {
        [Inject] private DefenceUnitPanelPresenter defenceUnitPanelPresenter;
        [Inject] private BoardPresenter boardPresenter;

        private void Update()
        {
            if (!defenceUnitPanelPresenter.IsAnySelected())
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out TilePresenter tile))
                    {
                        if(!tile.IsDefenceUnitPlaceable())
                        {
                            return;
                        }
                        DefenceUnitPresenter defenceUnit = defenceUnitPanelPresenter.GetSelectedDefenceUnit();
                        tile.SetDefenceUnit(defenceUnit);
                        CreateDefenceUnit(defenceUnit, tile.GetTilePosition());
                        defenceUnitPanelPresenter.OnSelectedUnitPlaced();
                    }
                }
            }
        }

        private void CreateDefenceUnit(DefenceUnitPresenter defenceUnit, Vector3 tilePosition)
        {
            var unit= Instantiate(defenceUnit);
            unit.SetPosition(tilePosition);
        }
    }
}