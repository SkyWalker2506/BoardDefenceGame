using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.MVP.View
{
    public class LineView : MonoBehaviour
    {
        public Transform LineTransform;
        
        public void SetLinePosition(Vector3 linePosition)
        {
            LineTransform.localPosition = linePosition;
        }

        public void SetTilePosition(TilePresenter tilePresenter, Vector3 position)
        {
            tilePresenter.SetTilePosition(position);
        }
    }
}