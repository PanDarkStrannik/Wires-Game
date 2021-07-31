using UnityEngine;

namespace UI
{
    public class LeaderBoardPanel : MonoBehaviour
    {
        [SerializeField] private ScoreBoardData _scoreBoardData;
        [SerializeField] private LeaderBoardLine _leaderBoardLine;
        [SerializeField] private Transform _parent;
        private void Start()
        {
            var scoreBoard = _scoreBoardData.ScoreBoard;
            for (int i = 0; i < scoreBoard.Count; i++)
            {
                var newLine = Instantiate(_leaderBoardLine, _parent);
                newLine.Initialize(scoreBoard[i].GamerName, scoreBoard[i].Points.ToString());
            }
        }

    }
}