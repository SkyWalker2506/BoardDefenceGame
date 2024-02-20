using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.MVP.View
{
    public class BoardView : MonoBehaviour
    {
        public Transform BoardTransform;

        public void SetBoardPosition(Vector3 boardPosition)
        {
            BoardTransform.localPosition = boardPosition;
        }

        public void UpdateLinePosition(LinePresenter line, Vector3 linePosition)
        {
            line.SetLinePosition(linePosition);
        }
    }
}