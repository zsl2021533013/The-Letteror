using Character.Base.Core.Core_Component;
using Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.Core.Core_Component
{
    public class ColossalBossMoveCore : MoveCore
    {
        [Header("Heart Hoarder Only")] 
        public float leftPointX;
        public float rightPointX;

        private float _targetPoint;

        public float Distance => Mathf.Abs(Position.x - _targetPoint);
        
        public int Attack2Direction
        {
            get
            {
                _targetPoint = Mathf.Abs(Position.x - leftPointX) > Mathf.Abs(Position.x - rightPointX)
                    ? leftPointX : rightPointX;
                return Position.x > _targetPoint ? -1 : 1;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(new Vector2(leftPointX, 1f), 1f);
            Gizmos.DrawWireSphere(new Vector2(rightPointX, 1f), 1f);
        }
    }
}