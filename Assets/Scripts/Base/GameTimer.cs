using System.Collections;
using UnityEngine;
using Difficult;
using System;

namespace GameBase
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private DifficultData _difficultData;
        [SerializeField] private float _timeStep = 0.3f;

        public event Action<float> OnTimeChanged;
        public event Action OnTimeEnd;

        private void Start()
        {
            StartTimer();
        }

        public void StartTimer()
        {
            StopAllCoroutines();
            StartCoroutine(Timer(_difficultData.GetTimeToGameEnd(Singleton<WinsHolder>.Instance.CurrentWins)));
        }

        private IEnumerator Timer(float timer)
        {
            while (timer > 0)
            {
                yield return new WaitForSeconds(_timeStep);
                timer -= _timeStep;
                if (timer < 0)
                    timer = 0;
                OnTimeChanged?.Invoke(timer);
            }
            OnTimeEnd?.Invoke();
        }
    }
}