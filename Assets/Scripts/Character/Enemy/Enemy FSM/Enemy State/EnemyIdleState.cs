using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_State
{
    public class EnemyIdleState : EnemyState
    {
        private bool _isDetectingPlayerFront;
        
        public EnemyIdleState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(enemyManager,
            enemyData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_isDetectingPlayerFront)
            {
                stateMachine.TranslateToState(enemyManager.ChaseState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isDetectingPlayerFront = coreManager.SenseCore.PlayerFront;
        }
    }
}