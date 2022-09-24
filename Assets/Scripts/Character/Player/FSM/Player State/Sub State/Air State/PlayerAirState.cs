using Character.Base.Manager;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Air_State
{
    public class PlayerAirState : PlayerState
    {
        private Vector2 _movementInput;
        private bool _jumpInput;
        private bool _jumpInputStop;
        private bool _dashInput;
        private bool _attackInput;
        private bool _specialAttackInput;
        private bool _isJumping;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingLedge;
        private bool _coyoteTime;


        public PlayerAirState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
           ResetTriggers(manager.Input);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            UpdateInput(manager.Input);

            CheckJumping();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.movementVelocity * _movementInput.x);
            coreManager.MoveCore.CheckFlip(manager.Input.MovementInput.x);
            
           manager.AnimationManager.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
           manager.AnimationManager.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (_attackInput)
            {
                CheckAirAttack();
                return;
            }

            if (_specialAttackInput)
            {
                CheckSpecialAttack();
                return;
            }
            
            if (_jumpInput && manager.JumpState.CheckAmountOfJump())
            {
                stateMachine.TranslateToState(manager.JumpState);
                manager.Input.ResetJumpInput();
                return;
            }
            
            if (manager.isDashEnable && _dashInput && manager.DashState.CheckAmountOfDash())
            {
                manager.Input.ResetDashInput();
                stateMachine.TranslateToState(manager.DashState);
                return;
            }

            if (_isGrounded && coreManager.MoveCore.CurrentVelocity.y < 0.01f)
            {
                stateMachine.TranslateToState(manager.LandState);
                return;
            }
            
            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded)
            {
                stateMachine.TranslateToState(manager.LedgeClimbState);
                return;
            }

            if (manager.isWallSlideEnable && _isTouchingWall &&manager.Input.InputDirection == coreManager.MoveCore.Direction &&
                coreManager.MoveCore.CurrentVelocity.y < 0.1f) 
            {
                stateMachine.TranslateToState(manager.WallSlideState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            CheckCoyoteTime();
            
            _isGrounded = coreManager.SenseCore.DetectGround;
            _isTouchingWall = coreManager.SenseCore.DetectWall;
            _isTouchingLedge = coreManager.SenseCore.DetectLedge;
            
            if (_isTouchingWall && !_isTouchingLedge)
            {
               manager.LedgeClimbState.SetPosition(manager.transform.position);
            }
        }

        private void UpdateInput(PlayerInputHandler input)
        {
            _movementInput = input.MovementInput;
            _jumpInput = input.JumpInput;
            _jumpInputStop = input.JumpInputStop;
            _dashInput = input.DashInput;
            _attackInput = input.AttackInput;
            _specialAttackInput = input.SpecialAttackInput;
        }

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > startTime + coreManager.MoveCore.StateMachineData.coyoteTime)
            {
                _coyoteTime = false;
               manager.JumpState.DecreaseAmountOfJumps();
            }
        }

        private void CheckJumping() // 用于制作可控的跳跃高度
        {
            if (_isJumping)
            {
                if (coreManager.MoveCore.CurrentVelocity.y < 0.01f)
                {
                    _isJumping = false;
                    return;
                }
                
                if (_jumpInputStop)
                {
                    coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.CurrentVelocity.y * coreManager.MoveCore.StateMachineData.variableJumpHeightMultiplier);
                    _isJumping = false;
                    return;
                }
            }
        }

        private void CheckAirAttack()
        {
            manager.Input.ResetAttackInput();
            switch (manager.Input.AttackDirection)
            {
                case AttackType.Horizontal:
                    if (manager.AirHorizontalAttack1State.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirHorizontalAttack1State);
                    }
                    break;
                case AttackType.Up:
                    if (manager.AirUpwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirUpwardsAttackState);
                    }
                    break;
                case AttackType.Down:
                    if (manager.AirDownwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirDownwardsAttackState);
                    }
                    break;
            }
        }
        
        private void CheckSpecialAttack()
        {
            manager.Input.ResetSpecialAttackInput();
            switch (manager.Input.SpecialAttackDirection)
            {
                case SpecialAttackType.Dash:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                case SpecialAttackType.Up:
                    if (manager.SpecialUpwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialUpwardsAttackState);
                    }
                    break;
                case SpecialAttackType.Down:
                    if (manager.SpecialDownwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDownwardsAttackState);
                    }
                    break;
                default:
                    if (manager.SpecialUpwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialUpwardsAttackState);
                    }
                    break;
            }
        }

        private void ResetTriggers(PlayerInputHandler input)
        {
            input.ResetDashInput();
            input.ResetAttackInput();
            input.ResetSpecialAttackInput();
        }
        
        public void StartCoyoteTime() => _coyoteTime = true;

        public void StartJumping() => _isJumping = true;
    }
} 