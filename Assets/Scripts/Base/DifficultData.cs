using UnityEngine;

namespace Difficult
{
    [CreateAssetMenu(fileName ="New Difficult Data", menuName = "Data/DifficultData")]
    public class DifficultData : ScriptableObject
    {
        [SerializeField] private AnimationCurve _timeToGameEndCurve;
        [SerializeField] private AnimationCurve _contactCountsCurve;

        public int GetContactCounts(int currentWins)
        {
            return (int)_contactCountsCurve.Evaluate(currentWins);
        }

        public float GetTimeToGameEnd(int currentWins)
        {
            return _timeToGameEndCurve.Evaluate(currentWins);
        }
    }
}