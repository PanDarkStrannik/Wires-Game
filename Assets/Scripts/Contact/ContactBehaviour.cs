using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Contact
{
    public class ContactBehaviour: MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        [SerializeField] private ContactData _contactData;
        [SerializeField] private Image _targetImage;

        public ContactData ContactData
        {
            get => _contactData;
        }

        private void OnEnable()
        {
            _targetImage.color = _contactData.GetColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            Singleton<ContactLineBehaviour>.Instance.SetEndLineContact(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            Singleton<ContactLineBehaviour>.Instance.SetStartLineContact(this);
        }
    }
}