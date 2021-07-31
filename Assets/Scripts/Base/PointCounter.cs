using System;
namespace GameBase
{
    public static class PointCounter
    {
        public static int CurrentPoints
        { get => _currentPoints; }

        private static int _currentPoints = 0;

        public static event Action<int> OnCurrentPointChanged;

        public static void AddPoint()
        {
            _currentPoints++;
            OnCurrentPointChanged?.Invoke(_currentPoints);
        }
        public static void ClearPoints()
        {
            _currentPoints = 0;
        }
    }
}