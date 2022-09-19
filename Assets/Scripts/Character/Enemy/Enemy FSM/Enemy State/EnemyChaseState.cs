using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_State
{
    public class EnemyChaseState : EnemyState
    {
        private bool _isDetectingPlayer;
        
        public EnemyChaseState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(enemyManager,
            enemyData, animBoolName)
        {
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_isDetectingPlayer)
            {
                coreManager.MoveCore.SetVelocityX(enemyData.moveVelocity * coreManager.MoveCore.Direction);
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _isDetectingPlayer = coreManager.SenseCore.PlayerFront;
        }
    }
}