using Character.Base.Manager;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Super_State
{
    public class PlayerGroundState : PlayerState
    {
        protected Vector2 movementInput;

        private bool _jumpInput;
        private bool _dashInput;
        private bool _rollInput;
        private bool _attackInput;
        private bool _isGrounded;
        
        public PlayerGroundState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

           manager.Input.ResetJumpInput();
           manager.Input.ResetDashInput();
           manager.Input.ResetAttackInput();
           manager.JumpState.ResetAmountOfJump();
           manager.DashState.ResetAmountOfDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            UpdateInput(manager.Input);
            
            if (_jumpInput &&manager.JumpState.CheckAmountOfJump())
            {
               manager.Input.ResetJumpInput();
                stateMachine.TranslateToState(manager.JumpState);
                return;
            }

            if (manager.isDashEnable && _dashInput &&manager.DashState.CheckAmountOfDash())
            {
               manager.Input.ResetDashInput();
                stateMachine.TranslateToState(manager.DashState);
                return;
            }
            
            if (_rollInput)
            {
               manager.Input.ResetRollInput();
                stateMachine.TranslateToState(manager.RollState);
                return;
            }

            if (_attackInput)
            {
               manager.Input.ResetAttackInput();
                stateMachine.TranslateToState(manager.Attack1State);
                return;
            }
            
            if (!_isGrounded)
            {
               manager.AirState.StartCoyoteTime();
                stateMachine.TranslateToState(manager.AirState);
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