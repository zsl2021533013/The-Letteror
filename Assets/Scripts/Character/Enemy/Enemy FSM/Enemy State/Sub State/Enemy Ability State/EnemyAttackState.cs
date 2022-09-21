using Character.Enemy.Data;
using Character.Enemy.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyAttackState : EnemyState
    {
        public bool AttackEnable => Time.time > startTime + enemyData.attackCoolDown;
        
        public EnemyAttackState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(
            enemyManager, enemyData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isAnimationFinish)
            {
                stateMachine.TranslateToState(enemyManager.IdleState);
            }
        }
    }
}