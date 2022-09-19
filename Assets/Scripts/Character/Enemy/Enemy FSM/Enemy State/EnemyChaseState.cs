using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_State
{
    public class EnemyChaseState : EnemyState
    {
        private bool _isDetectingPlayerFront;
        private bool _isDetectingPlayerBack;
        
        public EnemyChaseState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(enemyManager,
            enemyData, animBoolName)
        {
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_isDetectingPlayerFront)
            {
                coreManager.MoveCore.SetVelocityX(enemyData.moveVelocity * coreManager.MoveCore.Direction);
                return;
            }

            if (_isDetectingPlayerBack)
            {
                coreManager.MoveCore.Flip();
            }
            
            if (!_isDetectingPlayerFront && !_isDetectingPlayerBack)
            {
                stateMachine.TranslateToState(enemyManager.IdleState);
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _isDetectingPlayerFront = coreManager.SenseCore.PlayerFront;
            _isDetectingPlayerBack = coreManager.SenseCore.PlayerBack;
        }
    }
}