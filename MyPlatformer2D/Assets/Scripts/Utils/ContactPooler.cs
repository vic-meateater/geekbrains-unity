using UnityEngine;

namespace MyPlatformer2D
{
    public class ContactPooler
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];

        private int _contactsCount;
        private Collider2D _collider2D;
        private float _treshold;

        public bool IsGrounded { get; private set; }
        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider2D = collider;
        }

        public void Update()
        {
            IsGrounded = false;
            LeftContact = false;
            RightContact = false;

            _contactsCount = _collider2D.GetContacts(_contacts);
            for (int i = 0; i < _contactsCount; i++)
            {
                if (_contacts[i].normal.y > _treshold) IsGrounded = true;
                if (_contacts[i].normal.y > _treshold) LeftContact = true;
                if (_contacts[i].normal.y > _treshold) RightContact = true;
            }
        }
    }
}