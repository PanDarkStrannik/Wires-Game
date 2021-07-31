using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Contact
{
    public class ContactBehaviour: MonoBehaviour, IPointerEnterHandler, IPointerDownHandler//, IPointerUpHandler
    {
        [SerializeField] private ContactsDatabase _contactsDatabase;
        [SerializeField] private Type _contactType;
        [SerializeField] private Image _targetImage;
        [SerializeField] private RectTransform _rectTransform;

        public Type ContactType
        {
            get
            {
                return _contactType;
            }
        }
        public RectTransform RectTransform
        {
            get
            {
                return _rectTransform;
            }
        }

        public ContactData ContactData
        {
            get;
            private set;
        }

        public ContactsDatabase ContactsDatabase
        {
            get => _contactsDatabase;
        }

        public bool CanContact
        {
            get => _canContact;
        }

        private bool _canContact = true;


        private void Awake()
        {
            ContactData = _contactsDatabase.GetRandomContactData(_contactType);
            Singleton<ContactLineBehaviour>.Instance.OnContactSucsess += Instance_OnContactSucsess;
        }

        private void Instance_OnContactSucsess(ContactBehaviour _startContact, ContactBehaviour _endContact)
        {
            if (_startContact == this || _endContact == this)
                _canContact = false; 
        }

        private void OnEnable()
        {
            _targetImage.color = ContactData.GetColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            if (_canContact)
                Singleton<ContactLineBehaviour>.Instance.SetEndLineContact(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            if (_canContact)
                Singleton<ContactLineBehaviour>.Instance.SetStartLineContact(this);
        }

        public enum Type
        {
            Rigth, Left
        }
    }
}