using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDownwardsAttack1State : PlayerAttackState
    {
        private int _specialAttackAmountLeft;
        
        public PlayerSpecialDownwardsAttack1State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            DecreaseAmountOfSpecialAttack();
            
            coreManager.MoveCore.SetVelocityY(-coreManager.MoveCore.StateMachineData.specialDownwardsAttackVelocityY);
            coreManager.MoveCore.SetVelocityX(0f);
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.SpecialDownwardsAttack2State);
        }

        public bool CheckAmountOfSpecialAttack() =>
            _specialAttackAmountLeft - (manager.AbilityData.isSpecialDownwardsAttackEnable ? 0 : 1) > 0;

        public void ResetAmountOfSpecialAttack() => _specialAttackAmountLeft = coreManager.MoveCore.StateMachineData.specialAttackAmount;

        public void DecreaseAmountOfSpecialAttack() => --_specialAttackAmountLeft;
    }
}