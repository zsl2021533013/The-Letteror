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
        private bool _specialDashInput;
        private bool _attackInput;
        private bool _specialAttackInput;
        
        private bool _isJumping;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingLedge;
        private bool _isTouchingDashFruit;
        
        private Collider2D _oneWayPlatformCollider;

        private bool _coyoteTime;
        private float _targetVelocityX;
        private float _smoothDampVelocity;

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
            
            CheckJumping();

            _targetVelocityX = Mathf.SmoothDamp(manager.CoreManager.MoveCore.CurrentVelocity.x,
                coreManager.MoveCore.moveVelocity * _movementInput.x, ref _smoothDampVelocity,
                manager.CoreManager.MoveCore.StateMachineData.smoothDampTime);
            coreManager.MoveCore.SetVelocityX(_targetVelocityX);
            
            coreManager.MoveCore.CheckFlip(manager.Input);
            
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
                manager.Input.ResetJumpInput();
                stateMachine.TranslateToState(manager.JumpState);
                return;
            }
            
            if (manager.isDashEnable && _dashInput && manager.DashState.CheckAmountOfDash())
            {
                manager.Input.ResetDashInput();
                stateMachine.TranslateToState(manager.DashState);
                return;
            }

            if (_specialDashInput && _isTouchingDashFruit)
            {
                stateMachine.TranslateToState(manager.SpecialDashState);
                return;
            }

            if (_isGrounded && coreManager.MoveCore.CurrentVelocity.y < 0.01f)
            {
                stateMachine.TranslateToState(manager.LandState);
                return;
            }
            
            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded && !_oneWayPlatformCollider)
            {
                stateMachine.TranslateToState(manager.LedgeClimbState);
                return;
            }

            if (manager.isWallSlideEnable && _isTouchingWall && JudgeDirection(manager.Input.InputDirectionType,coreManager.MoveCore.CharacterDirection) &&
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
            _oneWayPlatformCollider = coreManager.SenseCore.DetectOneWayPlatform;
            _isTouchingDashFruit = coreManager.SenseCore.DetectDashFruit;
            
            if (_isTouchingWall && !_isTouchingLedge && !_oneWayPlatformCollider)
            {
               manager.LedgeClimbState.SetPosition(manager.transform.position);
            }
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            _movementInput = input.MovementInput;
            _jumpInput = input.JumpInput;
            _jumpInputStop = input.JumpInputStop;
            _dashInput = input.DashInput;
            _specialDashInput = input.SpecialDashInput;
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
            switch (manager.Input.InputDirectionType)
            {
                case PlayerInputDirectionType.Up:
                    if (manager.AirUpwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirUpwardsAttackState);
                    }
                    break;
                case PlayerInputDirectionType.Down:
                    if (manager.AirDownwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirDownwardsAttackState);
                    }
                    break;
                case PlayerInputDirectionType.Left:
                    if (manager.AirHorizontalAttack1State.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirHorizontalAttack1State);
                    }
                    break;
                case PlayerInputDirectionType.Right:
                    if (manager.AirHorizontalAttack1State.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirHorizontalAttack1State);
                    }
                    break;
                case PlayerInputDirectionType.None:
                    if (manager.AirHorizontalAttack1State.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirHorizontalAttack1State);
                    }
                    break;
                default:
                    if (manager.AirHorizontalAttack1State.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.AirHorizontalAttack1State);
                    }
                    break;
            }
        }
        
        private void CheckSpecialAttack()
        {
            manager.Input.ResetSpecialAttackInput();
            switch (manager.Input.InputDirectionType)
            {
                case PlayerInputDirectionType.Up:
                    if (manager.SpecialUpwardsAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialUpwardsAttackState);
                    }
                    break;
                case PlayerInputDirectionType.Down:
                    if (manager.SpecialDownwardsAttack1State.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDownwardsAttack1State);
                    }
                    break;
                case PlayerInputDirectionType.Left:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                case PlayerInputDirectionType.Right:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                case PlayerInputDirectionType.None:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                default:
                    if (manager.SpecialDashAttackState.AttackEnable)
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
            }
        }

        private bool JudgeDirection(PlayerInputDirectionType inputDirectionType,int playerDirection)
        {
            if (inputDirectionType == PlayerInputDirectionType.Right && playerDirection == 1)
            {
                return true;
            }
            
            if(inputDirectionType == PlayerInputDirectionType.Left && playerDirection == -1)
            {
                return true;
            }

            return false;
        }

        private void ResetTriggers(PlayerInputHandler input)
        {
            input.ResetDashInput();
            input.ResetSpecialDashInput();
            input.ResetAttackInput();
            input.ResetSpecialAttackInput();
        }
        
        public void StartCoyoteTime() => _coyoteTime = true;

        public void StartJumping() => _isJumping = true;
        public void EndJumping() => _isJumping = false;
    }
} 