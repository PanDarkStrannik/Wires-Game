using System.Collections.Generic;
using UnityEngine;
using Difficult;

namespace Contact
{
    public class ContactSpawner : MonoBehaviour
    {
        [SerializeField] private DifficultData _difficultData;
        [SerializeField] private ContactBehaviour _prefabForSpawn;
        [SerializeField] private Transform _parentForSpawnedObjects;

        public List<ContactBehaviour> AlreadySpawned
        {
            get
            {
                return _alreadySpawned;
            }
        }

        private List<ContactBehaviour> _alreadySpawned = new List<ContactBehaviour>();

        private void Start()
        {
            Spawn();
        }

        public void Spawn()
        {
            ClearScene();
            var contactCounts = _difficultData.GetContactCounts(Singleton<WinsHolder>.Instance.CurrentWins);
            for (int i = 0; i < contactCounts; i++)
            {
                var spawnedContact = Instantiate(_prefabForSpawn, _parentForSpawnedObjects);
                _alreadySpawned.Add(spawnedContact);
            }
        }

        private void ClearScene()
        {
            if(_alreadySpawned.Count > 0)
            {
                for(int i=0; i<_alreadySpawned.Count; i++)
                {
                    Destroy(_alreadySpawned[i].gameObject);
                }
            }
            _alreadySpawned.Clear();
        }
    }
}