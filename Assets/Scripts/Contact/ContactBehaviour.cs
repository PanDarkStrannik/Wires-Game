using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Contact
{
    public class ContactBehaviour: MonoBehaviour, IPointerEnterHandler, IPointerDownHandler//, IPointerUpHandler
    {
        [SerializeField] private ContactData _contactData;
        [SerializeField] private Image _targetImage;
        [SerializeField] private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get
            {
                return _rectTransform;
            }
        }

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
            //Singleton<ContactLineBehaviour>.Instance.SetLineContact(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            Singleton<ContactLineBehaviour>.Instance.SetStartLineContact(this);
            //Singleton<ContactLineBehaviour>.Instance.SetLineContact(this);
        }

        //public void OnPointerUp(PointerEventData eventData)
        //{
        //    if (eventData == null)
        //        throw new System.ArgumentNullException();
        //    Singleton<ContactLineBehaviour>.Instance.SetLineContact(this);
        //}
    }
}