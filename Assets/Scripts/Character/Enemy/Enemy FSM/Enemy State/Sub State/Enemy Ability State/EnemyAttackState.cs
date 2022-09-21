using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + ((EnemyMoveCore)coreManager.MoveCore).EnemyData.attackCoolDown;
        
        

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
                stateMachine.TranslateToState(((EnemyManager)characterManager).IdleState);
            }
        }
    }
}