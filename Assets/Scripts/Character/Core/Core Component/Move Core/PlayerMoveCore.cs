using UnityEngine;

namespace Character.Core.Core_Component
{
    public class PlayerMoveCore : PlayerCoreComponent
    {
        public Rigidbody2D Rb { get; private set; }
        
        public Vector2 CurrentVelocity { get; private set; }
        public int Direction => _transform.localScale.x > 0f ? 1 : -1;

        protected Transform _transform;
        private Vector2 _tempVector2;
        protected Vector3 _tempVector3;

        protected override void Awake()
        {
            base.Awake();

            Rb = GetComponentInParent<Rigidbody2D>();
            _transform = Rb.transform;
        }

        public void OnUpdate()
        {
            CurrentVelocity = Rb.velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            Rb.velocity = velocity;
        }
        
        public void SetVelocity(float velocity, Vector2 angle,int direction)
        {
            angle.Normalize();
            _tempVector2.Set(velocity * angle.x * direction, velocity * angle.y);
            Rb.velocity = _tempVector2;
        }
        
        public void SetVelocityX(float velocityX)
        {
            _tempVector2.Set(velocityX, Rb.velocity.y);
            Rb.velocity = _tempVector2;
        }
        
        public void SetVelocityY(float velocityY)
        {
            _tempVector2.Set(Rb.velocity.x, velocityY);
            Rb.velocity = _tempVector2;
        }

        public void Freeze(Vector2 position)
        {
            Rb.velocity = Vector2.zero;
            _transform.position = position;
        }
        
        public void FreezeX(Vector2 position)
        {
            _tempVector2.Set(0f, Rb.velocity.y);
            Rb.velocity = _tempVector2;
            _tempVector2.Set(position.x, _transform.position.y);
            _transform.position = _tempVector2;
        }
        
        public void FreezeY(Vector2 position)
        {
            _tempVector2.Set(Rb.velocity.x, 0f);
            Rb.velocity = _tempVector2;
            _tempVector2.Set(_transform.position.x, position.y);
            _transform.position = _tempVector2;
        }
        
        public void CheckFlip(float inputX)
        {
            int inputDirection = inputX > 0 ? 1 : -1;
            if (inputX == 0f)
            {
                inputDirection = 0;
            }
                
            if (inputDirection == -Direction)
            {
                _tempVector3.Set(inputDirection, 1, 1);
                _transform.localScale = _tempVector3;
            }
        }
    }
}