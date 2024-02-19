using BoardDefenceGame.MVP.Presenter;
using UnityEngine;

namespace BoardDefenceGame.MVP.View
{
    public class BoardView : MonoBehaviour
    {
        public Transform BoardTransform { get; private set; }

        public void SetBoardTransform(Transform tr)
        {
            BoardTransform = tr;
        }

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