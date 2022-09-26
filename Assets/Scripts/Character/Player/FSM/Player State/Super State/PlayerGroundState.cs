using Character.Base.Manager;
using Character.Player.Input_System;
using UnityEditorInternal;
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
        private bool _specialAttackInput;
        private bool _isGrounded;
        private PlayerInputDirection _inputDirection;
        private Collider2D _oneWayPlatformCollider;
        
        public PlayerGroundState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

           ResetTriggers(manager.Input);
           manager.ResetJumpAndDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            UpdateInput(manager.Input);
            
            if (_attackInput)
            {
                CheckGroundAttack();
                return;
            }
            
            if (_specialAttackInput)
            {
                CheckSpecialAttack();
                return;
            }

            if (_inputDirection == PlayerInputDirection.Down && _oneWayPlatformCollider)
            {
                coreManager.MoveCore.DisableOneWayPlatform(_oneWayPlatformCollider);
            }
            
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
            _oneWayPlatformCollider = coreManager.SenseCore.DetectOneWayPlatform;
        }

        private void UpdateInput(PlayerInputHandler input)
        {
            movementInput = input.MovementInput;
            _jumpInput = input.JumpInput;
            _dashInput = input.DashInput;
            _rollInput = input.RollInput;
            _attackInput = input.AttackInput;
            _specialAttackInput = input.SpecialAttackInput;
            _inputDirection = input.InputDirection;
        }

        private void ResetTriggers(PlayerInputHandler input)
        {
            input.ResetJumpInput();
            input.ResetDashInput();
            input.ResetAttackInput();
            input.ResetSpecialAttackInput();
        }
        
        private void CheckGroundAttack()
        {
            manager.Input.ResetAttackInput();
            switch (manager.Input.InputDirection)
            {
                case PlayerInputDirection.Up:
                    stateMachine.TranslateToState(manager.GroundUpwardsAttackState);
                    break;
                default:
                    stateMachine.TranslateToState(manager.GroundAttack1State);
                    break;
            }
        }
        
        private void CheckSpecialAttack()
        {
            manager.Input.ResetSpecialAttackInput();
            switch (manager.Input.InputDirection)
            {
                case PlayerInputDirection.Up:
                    if (manager.SpecialUpwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialUpwardsAttackState);
                    }
                    break;
                case PlayerInputDirection.Left:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                case PlayerInputDirection.Right:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                default:
                    if (manager.SpecialIdleAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialIdleAttackState);
                    }
                    break;
            }
        }
    }
}