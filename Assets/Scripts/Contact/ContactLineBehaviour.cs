using System;
using UnityEngine;

namespace Contact
{
    public class ContactLineBehaviour : MonoBehaviour
    {
        public event Action OnContactStart;
        public event Action OnContactEnd;
        public event Action OnContactFailed;
        public event Action<ContactBehaviour,ContactBehaviour> OnContactSucsess;

        public ContactBehaviour StartLineContact
        {
            get
            {
                return _startLineContact;
            }
        }
        public ContactBehaviour EndLineContact
        {
            get
            {
                return _endLineContact;
            }
        }

        private ContactBehaviour _startLineContact = null;
        private ContactBehaviour _endLineContact = null;

        public void SetStartLineContact(ContactBehaviour contactBehaviour)
        {
            if (_startLineContact == null)
            {
                _startLineContact = contactBehaviour;
                Debug.Log("Установили стартовую позицию линии!");
                OnContactStart?.Invoke();
            }
        }

        public void SetEndLineContact(ContactBehaviour contactBehaviour)
        {
            if (_startLineContact != null && _startLineContact.ContactType != contactBehaviour.ContactType)
            {
                _endLineContact = contactBehaviour;

                if (_startLineContact.ContactData.GetColor == _endLineContact.ContactData.GetColor)
                    OnContactSucsess?.Invoke(_startLineContact, _endLineContact);
                else
                    OnContactFailed?.Invoke();

            ClearContact();

            Debug.Log("Установили конечную позицию линии");
            }
        }

        public void ClearContact()
        {
            _startLineContact = null;
            _endLineContact = null;
            OnContactEnd?.Invoke();
        }
    }
}