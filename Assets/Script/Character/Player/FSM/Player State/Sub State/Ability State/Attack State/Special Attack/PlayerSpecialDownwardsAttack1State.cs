using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDownwardsAttack1State : PlayerAttackState
    {
        public PlayerSpecialDownwardsAttack1State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.StateMachineData.specialAttackCoolDown;

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(-coreManager.MoveCore.StateMachineData.specialDownwardsAttackVelocityY);
            coreManager.MoveCore.SetVelocityX(0f);
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.SpecialDownwardsAttack2State);
        }
    }
}