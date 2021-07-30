using UnityEngine;

namespace Contact
{
    [CreateAssetMenu(fileName = "New Contact Data", menuName = "Data/ContactData")]
    public class ContactData : ScriptableObject
    {
       [SerializeField] private Color _color;

        public Color GetColor
        {
            get
            {
                return _color;
            }
        }
    }
}