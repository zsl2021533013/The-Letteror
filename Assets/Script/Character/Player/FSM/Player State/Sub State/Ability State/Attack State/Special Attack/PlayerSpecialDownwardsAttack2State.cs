using Character.Base.Manager;
using Script.Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDownwardsAttack2State : PlayerAttackState
    {
        private bool _jumpInput;
        
        private bool _isGrounded;
        
        public PlayerSpecialDownwardsAttack2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
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

            coreManager.MoveCore.SetVelocityY(-coreManager.MoveCore.StateMachineData.specialDownwardsAttackVelocityY);

            if (_isGrounded)
            {
                stateMachine.TranslateToState(manager.SpecialDownwardsAttack3State);
                return;
            }
            
            if (_jumpInput)
            {
                coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.StateMachineData.specialDownwardsAttackStopVelocityY);
                stateMachine.TranslateToState(manager.AirState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = coreManager.SenseCore.DetectGround;
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            base.UpdateInput(input);

            _jumpInput = input.JumpInput;
        }
    }
}