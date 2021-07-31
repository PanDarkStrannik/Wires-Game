using System.Collections.Generic;
using UnityEngine;

namespace Contact
{
    [CreateAssetMenu(fileName = "New Contacts Database", menuName = "Data/ContactsDatabase")]
    public class ContactsDatabase : ScriptableObject
    {
        [SerializeField] private List<ContactTypeListDataComparer> _database;

        private List<ContactTypeDataComparer> _typesDatasPairs = new List<ContactTypeDataComparer>();

        public ContactData GetRandomContactData(ContactBehaviour.Type contactType)
        {
            if (_typesDatasPairs.Find(x => x.ContactType == contactType) == null && _typesDatasPairs.Count > 0)
            {
                var randNum = Random.Range(0, _typesDatasPairs.Count);
                var randomContactData = _typesDatasPairs[randNum].ContactData;
                _typesDatasPairs.RemoveAt(randNum);
                return randomContactData;
            }
            else
            {
                var databaseByCurrentContactType = _database.FindAll(x => x.ContactType == contactType);

                var randDatabase = Random.Range(0, databaseByCurrentContactType.Count);

                var randomContactData = databaseByCurrentContactType[randDatabase].GetRandomContactData();
                _typesDatasPairs.Add(new ContactTypeDataComparer(contactType, randomContactData));

                return randomContactData;
            }
        }

        [System.Serializable]
        private class ContactTypeListDataComparer
        {
            [SerializeField] private ContactBehaviour.Type _contactType;
            [SerializeField] private List<ContactData> _contactsDatas;

            public ContactBehaviour.Type ContactType
            { get => _contactType; }

            private List<ContactData> _tempContactsDatas = new List<ContactData>();

            public ContactData GetRandomContactData()
            {
                if (_tempContactsDatas.Count == 0)
                    _tempContactsDatas = new List<ContactData>(_contactsDatas);

                var randContactNum = Random.Range(0, _tempContactsDatas.Count);
                var randContactData = _tempContactsDatas[randContactNum];
                _tempContactsDatas.Remove(randContactData);

                return randContactData;
            }

        }
        private class ContactTypeDataComparer
        {
            public ContactBehaviour.Type ContactType
            { get; private set; }
            public ContactData ContactData
            { get; private set; }

            public ContactTypeDataComparer(ContactBehaviour.Type type, ContactData data)
            {
                ContactType = type;
                ContactData = data;
            }
        }
    }
}