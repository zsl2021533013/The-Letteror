using Character.Base.Base_Manager;
using Character.Player.Data;
using Character.Player.Input_System;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using UnityEngine;

namespace Character.Player.Player_State.Super_State
{
    public class PlayerGroundState : PlayerState
    {
        protected Vector2 movementInput;

        private bool _jumpInput;
        private bool _dashInput;
        private bool _rollInput;
        private bool _attackInput;
        private bool _isGrounded;
        
        public PlayerGroundState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            ((PlayerManager)characterManager).Input.ResetJumpInput();
            ((PlayerManager)characterManager).Input.ResetDashInput();
            ((PlayerManager)characterManager).Input.ResetAttackInput();
            ((PlayerManager)characterManager).JumpState.ResetAmountOfJump();
            ((PlayerManager)characterManager).DashState.ResetAmountOfDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            UpdateInput(((PlayerManager)characterManager).Input);
            
            if (_jumpInput && ((PlayerManager)characterManager).JumpState.CheckAmountOfJump())
            {
                ((PlayerManager)characterManager).Input.ResetJumpInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).JumpState);
                return;
            }

            if (((PlayerManager)characterManager).isDashEnable && _dashInput && ((PlayerManager)characterManager).DashState.CheckAmountOfDash())
            {
                ((PlayerManager)characterManager).Input.ResetDashInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).DashState);
                return;
            }
            
            if (_rollInput)
            {
                ((PlayerManager)characterManager).Input.ResetRollInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).RollState);
                return;
            }

            if (_attackInput)
            {
                ((PlayerManager)characterManager).Input.ResetAttackInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).Attack1State);
                return;
            }
            
            if (!_isGrounded)
            {
                ((PlayerManager)characterManager).AirState.StartCoyoteTime();
                stateMachine.TranslateToState(((PlayerManager)characterManager).AirState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = coreManager.SenseCore.DetectGround;
        }

        private void UpdateInput(PlayerInputHandler input)
        {
            movementInput = input.MovementInput;
            _jumpInput = input.JumpInput;
            _dashInput = input.DashInput;
            _rollInput = input.RollInput;
            _attackInput = input.AttackInput;
        }
    }
}