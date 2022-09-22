using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Air_State
{
    public class PlayerAirState : PlayerState
    {
        private Vector2 _movementInput;
        private bool _jumpInput;
        private bool _jumpInputStop;
        private bool _dashInput;
        private bool _attackInput;
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
            
           manager.Input.ResetDashInput();
           manager.Input.ResetAttackInput();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _movementInput =manager.Input.MovementInput;
            _jumpInput =manager.Input.JumpInput;
            _jumpInputStop =manager.Input.JumpInputStop;
            _dashInput =manager.Input.DashInput;
            _attackInput =manager.Input.AttackInput;
            
            CheckJumping();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.movementVelocity * _movementInput.x);
            coreManager.MoveCore.CheckFlip(manager.Input.MovementInput.x);
            
           manager.Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
           manager.Anim.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (_jumpInput &&manager.JumpState.CheckAmountOfJump())
            {
                stateMachine.TranslateToState(manager.JumpState);
               manager.Input.ResetJumpInput();
                return;
            }
            
            if (manager.isDashEnable && _dashInput &&manager.DashState.CheckAmountOfDash())
            {
               manager.Input.ResetDashInput();
                stateMachine.TranslateToState(manager.DashState);
                return;
            }

            if (_attackInput)
            {
               manager.Input.ResetAttackInput();
                stateMachine.TranslateToState(manager.Attack1State);
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

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > startTime + coreManager.MoveCore.PlayerData.coyoteTime)
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
                    coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.CurrentVelocity.y * coreManager.MoveCore.PlayerData.variableJumpHeightMultiplier);
                    _isJumping = false;
                    return;
                }
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;

        public void StartJumping() => _isJumping = true;
    }
} 