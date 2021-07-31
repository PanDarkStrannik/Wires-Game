using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameBase;

namespace UI
{
    [CreateAssetMenu(fileName = "New ScoreBoardData", menuName = "Data/ScoreBoardData")]
    public class ScoreBoardData : ScriptableObject
    {
        [SerializeField] private List<ScoreNameComparer> _scoreBoard = new List<ScoreNameComparer>();
        [SerializeField, Min(0)] private int _maximumTop = 10;
        public List<ScoreNameComparer> ScoreBoard
        { get => _scoreBoard; }

        public void AddNewRecord(string gamerName, int _points)
        {
            var newRecord = new ScoreNameComparer(gamerName, _points);
            if (_scoreBoard.TrueForAll(x => x.GamerName != newRecord.GamerName))
            {
                _scoreBoard.Add(newRecord);
                _scoreBoard = _scoreBoard.OrderByDescending(x => x.Points).ToList();
            }

            if (_scoreBoard.Count > _maximumTop && _scoreBoard.Count > 0)
            {
                _scoreBoard.RemoveAt(_scoreBoard.Count - 1);
            }
            PointCounter.ClearPoints();
        }

        [System.Serializable]
        public class ScoreNameComparer
        {
            [SerializeField] private string _gamerName;
            [SerializeField] private int _points;

            public string GamerName
            { get => _gamerName; }
            public int Points
            { get => _points; }

            public ScoreNameComparer(string gamerName, int points)
            {
                _gamerName = gamerName;
                _points = points;
            }
        }
    }
}