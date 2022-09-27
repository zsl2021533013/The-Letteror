using System;
using Character.Base.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder.Core.Core_Component
{
    public class HeartHoarderMoveCore : MoveCore
    {
        [Header("Heart Hoarder Only")] 
        public float leftPointX;
        public float rightPointX;
        public float middlePointX;
        public Vector2 LeftPointPosition => new Vector2(leftPointX, Position.y);
        public Vector2 RightPointPosition => new Vector2(rightPointX, Position.y);
        public Vector2 MiddlePointPosition => new Vector2(middlePointX, Position.y);

        public void MoveTo(Vector2 newPosition)
        {
            coreManager.CharacterTransform.position = newPosition;
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