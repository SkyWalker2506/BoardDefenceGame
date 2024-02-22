using BoardDefenceGame.MVP.Presenter;
using BoardDefenceGame.UI.MVP.Presenter;
using DependencyInjection;
using UnityEngine;

namespace BoardDefenceGame.Manager
{
    public class DefenceUnitPlacementManager : MonoBehaviour
    {
        [Inject] private DefenceUnitPanelPresenter defenceUnitPanelPresenter;

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
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.TryGetComponent(out TilePresenter tile))
                    {
                        Debug.Log(tile.name);
                        if(tile.IsTileOccupied())
                        {
                            return;
                        }
                        DefenceUnitPresenter defenceUnit = defenceUnitPanelPresenter.GetSelectedDefenceUnit();
                        tile.SetDefenceUnit(defenceUnit);
                        CreateDefenceUnit(defenceUnit, tile.GetTilePosition());
                        defenceUnitPanelPresenter.OnSelectedUnitPlaced();
                    }
                }
                else
                {
                    Debug.Log("No hit");
                }
            }
        }

        private void CreateDefenceUnit(DefenceUnitPresenter defenceUnit, Vector3 tilePosition)
        {
            Instantiate(defenceUnit, tilePosition, Quaternion.identity);
        }
    }
}