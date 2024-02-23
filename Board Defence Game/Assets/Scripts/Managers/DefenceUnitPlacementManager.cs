using System.Collections.Generic;
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
        [HideInInspector] public List<DefenceUnitPresenter> PlacedDefenceUnits = new ();
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
                        CreateDefenceUnit(defenceUnit, tile);
                        defenceUnitPanelPresenter.OnSelectedUnitPlaced();
                    }
                }
            }
        }

        private void CreateDefenceUnit(DefenceUnitPresenter defenceUnit, TilePresenter tile)
        {
            var unit = Instantiate(defenceUnit);
            unit.SetIndex(tile.GetLineIndex(), tile.GetTileIndex());
            unit.SetPosition(tile.GetTilePosition());
            tile.SetDefenceUnit(unit);
            PlacedDefenceUnits.Add(unit);
        }

        public List<DefenceUnitPresenter> GetPlacedDefenceUnits()
        {
            return PlacedDefenceUnits;
        }
    }
}