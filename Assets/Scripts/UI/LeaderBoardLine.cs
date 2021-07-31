using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LeaderBoardLine : MonoBehaviour
    {
        [SerializeField] private Text _playerNameViewer;
        [SerializeField] private Text _scoreViewer;

        public void Initialize(string playerName, string score)
        {
            _playerNameViewer.text = playerName;
            _scoreViewer.text = score;
        }
    }
}