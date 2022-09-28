using Character.Base.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.Core.Core_Component
{
    public class BloodKingMoveCore : MoveCore
    {
        [Header("Heart Hoarder Only")] 
        public float leftPointX;
        public float rightPointX;

        public float attack3_1Veclocity;
        public float attack3_2Veclocity;
        public float attack3_3Veclocity;
        public float attack3_4Veclocity;
        public float attack4_1Veclocity;
        public float attack4_2Veclocity;
        
        public Vector2 LeftPointPosition => new(leftPointX, Position.y);
        public Vector2 RightPointPosition => new(rightPointX, Position.y);

        private float _targetPoint;

        public void MoveTo(Vector2 newPosition)
        {
            coreManager.CharacterTransform.position = newPosition;
        }
        
        public void MoveTo(float newPositionX)
        {
            coreManager.CharacterTransform.position = new Vector3(newPositionX, Position.y);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(new Vector2(leftPointX, 1f), 1f);
            Gizmos.DrawWireSphere(new Vector2(rightPointX, 1f), 1f);
        }
    }
}