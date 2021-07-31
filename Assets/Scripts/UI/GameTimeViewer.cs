using UnityEngine;
using UnityEngine.UI;
using System;
using GameBase;

namespace UI
{
    public class GameTimeViewer : MonoBehaviour
    {
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private Text _gameTimerText;
        [SerializeField] private string _beforeGameTimerText;

        private void Awake()
        {
            _gameTimer.OnTimeChanged += OnTimeChanged;
        }

        private void OnTimeChanged(float currentTime)
        {
            _gameTimerText.text = $"{_beforeGameTimerText} {Math.Round(currentTime, 2)}";
        }
    }
}