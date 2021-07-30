using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Contact
{
    public class ContactLineDrawer : MonoBehaviour, IDragHandler
    {
        private bool _haveContact = false;
        private void Start()
        {
            Singleton<ContactLineBehaviour>.Instance.OnContactStart += Instance_OnContactStart;
            Singleton<ContactLineBehaviour>.Instance.OnContactEnd += Instance_OnContactEnd;
        }

        private void Instance_OnContactStart()
        {
            _haveContact = true;
        }

        private void Instance_OnContactEnd()
        {
            _haveContact = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException();
            if(_haveContact)
            {

            }
        }
    }
}