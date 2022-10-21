using Character.Base.Manager;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialUpwardsAttackState : PlayerAttackState
    {
        private Vector2 movementInput;
        private int _specialAttackAmountLeft;
        
        public PlayerSpecialUpwardsAttackState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            DecreaseAmountOfSpecialAttack();
            
            coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.StateMachineData.specialUpwardsAttackVelocityY);
            coreManager.MoveCore.FreezeX(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * movementInput.x);
        }


        protected override void UpdateInput(PlayerInputHandler input)
        {
            base.UpdateInput(input);

            movementInput = input.MovementInput;
        }

        public bool CheckAmountOfSpecialAttack() =>
            _specialAttackAmountLeft - (manager.AbilityData.isSpecialUpwardsAttackEnable ? 0 : 1) > 0;

        public void ResetAmountOfSpecialAttack() => _specialAttackAmountLeft = coreManager.MoveCore.StateMachineData.specialAttackAmount;

        public void DecreaseAmountOfSpecialAttack() => --_specialAttackAmountLeft;
    }
}