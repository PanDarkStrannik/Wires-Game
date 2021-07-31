using GameBase;
using UnityEngine;

namespace Difficult
{
    public class WinsHolder : MonoBehaviour
    {
        [SerializeField] private GameOverLogic _gameOverLogic;

        private int _currentWins = 0;
        public int CurrentWins
        {
            get
            {
                return _currentWins;
            }
        }

        private void Awake()
        {
            _gameOverLogic.OnWinEvent.AddListener(ScaleDifficult);
        }

        private void ScaleDifficult()
        {
            _currentWins++;
        }

    }
}