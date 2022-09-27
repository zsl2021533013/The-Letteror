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
        public float stopDistance;

        private float _targetPoint; 
        private Transform _playerTransform;
        
        public int ChaseDirection
        {
            get
            {
                _targetPoint = _playerTransform.position.x;
                return Position.x > _playerTransform.position.x ? -1 : 1;
            }
        }
        
        public int Attack2Direction
        {
            get
            {
                _targetPoint = Mathf.Abs(Position.x - leftPointX) > Mathf.Abs(Position.x - rightPointX)
                    ? leftPointX : rightPointX;
                return Position.x > _targetPoint ? -1 : 1;
            }
        }
        
        protected override void Start()
        {
            base.Start();
            
            _playerTransform = GameManager.Instance.PlayerTransform;
        }
        
        public void Flip()
        {
            tempVector3.Set(-transform.localScale.x, 1, 1);
            transform.localScale = tempVector3;
        }
        
        public bool JudgeArrivePoint()
        {
            if (Mathf.Abs(Position.x - _targetPoint) < stopDistance)
            {
                return true;
            }

            return false;
        }
        
        public bool JudgeArrivePlayer()
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
        }
    }
}