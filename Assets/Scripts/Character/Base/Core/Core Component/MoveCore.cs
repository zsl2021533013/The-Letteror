using System;
using UnityEngine;

namespace Character.Base.Core.Core_Component
{
    public class MoveCore : CoreComponent
    {
        [Header("Move State")] 
        public float moveVelocity;

        protected Transform characterTransform;
        protected Vector2 tempVector2;
        protected Vector3 tempVector3;
        
        public Rigidbody2D Rb { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        
        public int Direction => characterTransform.localScale.x > 0f ? 1 : -1;
        public Vector2 Position => characterTransform.position;

        protected override void Awake()
        {
            base.Awake();

            Rb = GetComponentInParent<Rigidbody2D>();
            characterTransform = Rb.transform;
        }

        protected virtual void Start()
        {
            
        }

        public virtual void OnUpdate()
        {
            CurrentVelocity = Rb.velocity;
        }

        public void Flip()
        {
            tempVector3.Set(-characterTransform.localScale.x, 1, 1);
            characterTransform.localScale = tempVector3;
        }
        
        public void SetVelocity(Vector2 velocity)
        {
            Rb.velocity = velocity;
        }
        
        public void SetVelocity(float velocity, Vector2 angle,int direction)
        {
            angle.Normalize();
            tempVector2.Set(velocity * angle.x * direction, velocity * angle.y);
            Rb.velocity = tempVector2;
        }
        
        public void SetVelocityX(float velocityX)
        {
            tempVector2.Set(velocityX, Rb.velocity.y);
            Rb.velocity = tempVector2;
        }
        
        public void SetVelocityY(float velocityY)
        {
            tempVector2.Set(Rb.velocity.x, velocityY);
            Rb.velocity = tempVector2;
        }

        public void Freeze(Vector2 position)
        {
            Rb.velocity = Vector2.zero;
            characterTransform.position = position;
        }
        
        public void FreezeX(Vector2 position)
        {
            tempVector2.Set(0f, Rb.velocity.y);
            Rb.velocity = tempVector2;
            tempVector2.Set(position.x, characterTransform.position.y);
            characterTransform.position = tempVector2;
        }
        
        public void FreezeY(Vector2 position)
        {
            tempVector2.Set(Rb.velocity.x, 0f);
            Rb.velocity = tempVector2;
            tempVector2.Set(characterTransform.position.x, position.y);
            characterTransform.position = tempVector2;
        }
    }
}