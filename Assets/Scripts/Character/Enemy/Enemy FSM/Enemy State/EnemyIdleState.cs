using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_State
{
    public class EnemyIdleState : EnemyState
    {
        private bool _isDetectingPlayer;
        
        public EnemyIdleState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(enemyManager,
            enemyData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_isDetectingPlayer)
            {
                stateMachine.TranslateToState(enemyManager.ChaseState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isDetectingPlayer = coreManager.SenseCore.PlayerFront;
        }
    }
}