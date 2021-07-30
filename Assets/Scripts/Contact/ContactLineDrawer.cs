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
        //[SerializeField,Min(2)] private int _maxDots = 2;

        private bool _haveContact = false;
        private ContactLineBehaviour _lineBehaviour = null;
        private Color _dottedLineDefaultColor = default;

        private void Start()
        {
            _dottedLineDefaultColor = _dottedLine.startColor;
            //_dottedLine.positionCount = _maxDots;

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

            //float width = _dottedLine.startWidth;
            //_dottedLine.material.mainTextureScale = new Vector2(1f / width, 1.0f);
        }

        private void OnContactSucsess()
        {
            ClearDottedLine();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            if (_haveContact)
            {
                var pointerPosition = eventData.pointerCurrentRaycast.worldPosition;

                pointerPosition.z = 0;
                //var offset = Vector3.Distance(pointerPosition, _dottedLine.GetPosition(0)) / _maxDots;

                //for (int i = 1; i < _dottedLine.positionCount; i++)
                //{
                //    var direction = Vector3.Normalize(pointerPosition - _dottedLine.GetPosition(i-1));
                //    var newPos = new Vector3(direction.x + offset, direction.y + offset, 0);
                //    _dottedLine.SetPosition(i, newPos);
                //}
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

        //private void LateUpdate()
        //{
        //    if (_haveContact)
        //    {
        //        var pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        pointerPosition.z = 0;
        //        _dottedLine.SetPosition(_dottedLine.positionCount - 1, pointerPosition);
        //        Debug.Log("Что-то работает!");
        //    }
        //}
    }
}