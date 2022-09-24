using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCatcher : MonoBehaviour
{
    [SerializeField]

    public class CaughtObject 
    {
        public Rigidbody2D rigidbody;
        public Collider2D collider;
        //public Player player;
        public bool inContact;
        public bool checkedThisFrame;

        public void Move(Vector2 movement)
        {
            if (!inContact)
                return;

            rigidbody.MovePosition(rigidbody.position + movement);
        }

        public Rigidbody2D platformRigidbody;
        public ContactFilter2D contactFilter;

        protected List<CaughtObject> m_CaughtObjects = new List<CaughtObject>(128);
    }
}
