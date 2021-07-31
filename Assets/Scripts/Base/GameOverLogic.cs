using UnityEngine;
using Contact;
using System.Collections.Generic;
using UnityEngine.Events;

namespace GameBase
{
    public class GameOverLogic : MonoBehaviour
    {
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private List<ContactSpawner> _contactSpawners;
        [SerializeField] public UnityEvent OnWinEvent;
        [SerializeField] public UnityEvent OnLooseEvent;

        private void Awake()
        {
            _gameTimer.OnTimeEnd += OnLoose;
            Singleton<ContactLineBehaviour>.Instance.OnContactFailed += OnLoose;
            Singleton<ContactLineBehaviour>.Instance.OnContactEnd += CheckOnWin;
            Singleton<ContactLineBehaviour>.Instance.OnContactSucsess += Instance_OnContactSucsess;
        }

        private void Instance_OnContactSucsess(ContactBehaviour startContact, ContactBehaviour endContact)
        {
            PointCounter.AddPoint();
        }

        public void CheckOnWin()
        {
            int counter = 0;
            foreach(var contactSpawner in _contactSpawners)
            {
                if (contactSpawner.AlreadySpawned.TrueForAll(x => x.CanContact == false))
                {
                    counter++;
                }
            }
            if (counter == _contactSpawners.Count)
            {
                OnWinEvent?.Invoke();
                foreach (var contactSpawner in _contactSpawners)
                    contactSpawner.Spawn();
                _gameTimer.StartTimer();
            }
        }

        public void OnLoose()
        {
            OnLooseEvent?.Invoke();
        }
    }
}