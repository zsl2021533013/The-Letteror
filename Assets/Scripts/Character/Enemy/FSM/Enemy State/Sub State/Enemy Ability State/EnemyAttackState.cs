using Character.Base.Manager;
using Character.Enemy.FSM.Enemy_State.Super_State;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyAttackState : EnemyAbilityState
    {
        public EnemyAttackState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.EnemyStateMachineData.attackCoolDown;

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }
        
    }
}