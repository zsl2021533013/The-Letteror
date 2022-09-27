using System;
using Character.Base.Core.Core_Component;
using Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder.Core.Core_Component
{
    public class HeartHoarderMoveCore : MoveCore
    {
        [Header("Heart Hoarder Only")] 
        public float leftPointX;
        public float rightPointX;
        public float middlePointX;
        public float stopDistance;
        public Vector2 LeftPointPosition => new Vector2(leftPointX, Position.y);
        public Vector2 RightPointPosition => new Vector2(rightPointX, Position.y);
        public Vector2 MiddlePointPosition => new Vector2(middlePointX, Position.y);
        
        private Transform _playerTransform;
        
        public int ChaseDirection => Position.x > _playerTransform.position.x ? -1 : 1;

        protected override void Start()
        {
            base.Start();
            
            _playerTransform = GameManager.Instance.PlayerTransform;
        }

        public void MoveTo(Vector2 newPosition)
        {
            coreManager.CharacterTransform.position = newPosition;
        }

        public bool JudgeArrive()
        {
            if (Mathf.Abs(Position.x - _playerTransform.position.x) < stopDistance)
            {
                return true;
            }

            return false;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(new Vector2(leftPointX, 1f), 1f);
            Gizmos.DrawWireSphere(new Vector2(rightPointX, 1f), 1f);
            Gizmos.DrawWireSphere(new Vector2(middlePointX, 1f), 1f);
        }
    }
}