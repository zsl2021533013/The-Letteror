using Character.Base.Manager;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.EnemyData.attackCoolDown;

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
                stateMachine.TranslateToState(manager.IdleState);
            }
        }
    }
}