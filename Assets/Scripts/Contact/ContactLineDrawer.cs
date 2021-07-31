using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Contact
{
    public class ContactLineDrawer : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private LineRenderer _dottedLine;
        [SerializeField] private LineRenderer _contactLinePrefab;
        //[SerializeField,Min(2)] private int _maxDots = 2;

        private bool _haveContact = false;
        private ContactLineBehaviour _lineBehaviour = null;
        private Color _dottedLineDefaultColor = default;

        private void Start()
        {
            _dottedLineDefaultColor = _dottedLine.startColor;

            _lineBehaviour = Singleton<ContactLineBehaviour>.Instance;
            _lineBehaviour.OnContactStart += Instance_OnContactStart;
            _lineBehaviour.OnContactSucsess += OnContactSucsess;
            _lineBehaviour.OnContactEnd += ClearDottedLine;
        }

        private void ClearDottedLine()
        {
            _haveContact = false;
            _dottedLine.positionCount = 0;
            _dottedLine.startColor = _dottedLineDefaultColor;
            _dottedLine.endColor = _dottedLineDefaultColor;
        }

        private void Instance_OnContactStart()
        {
            _haveContact = true;
            _dottedLine.positionCount = 2;
            var startLineContact = _lineBehaviour.StartLineContact;

            _dottedLine.startColor = startLineContact.ContactData.GetColor;
            _dottedLine.endColor = startLineContact.ContactData.GetColor;

            var startLineContactPostion = new Vector3(startLineContact.RectTransform.position.x, startLineContact.RectTransform.position.y);

            _dottedLine.SetPosition(0, startLineContactPostion);
            _dottedLine.SetPosition(_dottedLine.positionCount - 1, startLineContactPostion);

        }

        private void OnContactSucsess(ContactBehaviour _startContact, ContactBehaviour _endContact)
        {
            ClearDottedLine();
            var contactLine = Instantiate(_contactLinePrefab, _startContact.transform);
            contactLine.positionCount = 2;
            contactLine.startColor = _startContact.ContactData.GetColor;
            contactLine.endColor = _endContact.ContactData.GetColor;
            contactLine.SetPosition(0, _startContact.RectTransform.position);
            contactLine.SetPosition(1, _endContact.RectTransform.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            if (_haveContact)
            {
                var pointerPosition = eventData.pointerCurrentRaycast.worldPosition;

                pointerPosition.z = 0;
                _dottedLine.SetPosition(_dottedLine.positionCount - 1, pointerPosition);
                Debug.Log("Что-то работает!");
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            if(_haveContact)
            {
                _lineBehaviour.ClearContact();
            }
        }
    }
}