using UnityEngine;
using UnityEngine.UI;
using GameBase;

namespace UI
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private string _beforeScore;
        private void Awake()
        {
            PointCounter.OnCurrentPointChanged += OnCurrentPointChanged;
            ChangeScoreText(PointCounter.CurrentPoints);
        }

        private void OnCurrentPointChanged(int scoreValue)
        {
            ChangeScoreText(scoreValue);
        }

        private void ChangeScoreText(int scoreValue)
        {
            _scoreText.text = $"{_beforeScore} {scoreValue}";
        }

        private void OnDestroy()
        {
            PointCounter.OnCurrentPointChanged -= OnCurrentPointChanged;
        }
    }
}