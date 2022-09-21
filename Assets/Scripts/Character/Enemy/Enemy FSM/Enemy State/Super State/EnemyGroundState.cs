using Character.Core.Core_Component;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Super_State
{
    public class EnemyGroundState : EnemyState
    {
        protected bool inChaseRange;
        protected bool inAttackRange;
        
        
        public EnemyGroundState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(
            enemyManager, enemyData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (inChaseRange && !inAttackRange)
            {
                stateMachine.TranslateToState(enemyManager.ChaseState);
                return;
            }
            
            if (inAttackRange && enemyManager.AttackState.AttackEnable)
            {
                stateMachine.TranslateToState(enemyManager.AttackState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            inChaseRange = ((EnemySenseCore)coreManager.SenseCore).InChaseRange;
            inAttackRange = ((EnemySenseCore)coreManager.SenseCore).InAttackRange;
        }
    }
}