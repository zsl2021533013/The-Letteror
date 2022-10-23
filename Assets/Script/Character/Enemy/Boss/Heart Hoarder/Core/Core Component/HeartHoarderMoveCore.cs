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

        public Vector2 LeftPointPosition => new(leftPointX, Position.y);
        public Vector2 RightPointPosition => new(rightPointX, Position.y);
        public Vector2 MiddlePointPosition => new(middlePointX, Position.y);


        public void MoveTo(Vector2 newPosition)
        {
            coreManager.CharacterTransform.position = newPosition;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(new Vector2(leftPointX, transform.position.y), 1f);
            Gizmos.DrawWireSphere(new Vector2(rightPointX, transform.position.y), 1f);
            Gizmos.DrawWireSphere(new Vector2(middlePointX, transform.position.y), 1f);
        }
    }
}