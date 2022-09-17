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
        
        public PlayerAirState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.Input.ResetDashInput();
            playerManager.Input.ResetAttackInput();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _movementInput = playerManager.Input.MovementInput;
            _jumpInput = playerManager.Input.JumpInput;
            _jumpInputStop = playerManager.Input.JumpInputStop;
            _dashInput = playerManager.Input.DashInput;
            _attackInput = playerManager.Input.AttackInput;
            
            CheckJumping();
            
            playerManager.SetVelocityX(playerData.movementVelocity * _movementInput.x);
            
            playerManager.CheckPlayerFlip();
            
            playerManager.Anim.SetFloat("velocityX", Mathf.Abs(playerManager.Rb.velocity.x));
            playerManager.Anim.SetFloat("velocityY", playerManager.Rb.velocity.y);

            if (_jumpInput && playerManager.JumpState.CheckAmountOfJump())
            {
                stateMachine.TranslateToState(playerManager.JumpState);
                playerManager.Input.ResetJumpInput();
                return;
            }
            
            if (_dashInput && playerManager.DashState.CheckAmountOfDash())
            {
                playerManager.Input.ResetDashInput();
                stateMachine.TranslateToState(playerManager.DashState);
                return;
            }

            if (_attackInput)
            {
                playerManager.Input.ResetAttackInput();
                stateMachine.TranslateToState(playerManager.Attack1State);
                return;
            }

            if (_isGrounded && playerManager.Rb.velocity.y < 0.01f)
            {
                stateMachine.TranslateToState(playerManager.LandState);
                return;
            }
            
            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded)
            {
                stateMachine.TranslateToState(playerManager.LedgeClimbState);
                return;
            }

            if (_isTouchingWall && playerManager.Input.InputDirection == playerManager.PlayerDirection &&
                playerManager.Rb.velocity.y < 0.1f) 
            {
                stateMachine.TranslateToState(playerManager.WallSlideState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            CheckCoyoteTime();
            
            _isGrounded = playerManager.CheckGrounded();
            _isTouchingWall = playerManager.CheckWall();
            _isTouchingLedge = playerManager.CheckLedge();
            
            if (_isTouchingWall && !_isTouchingLedge)
            {
                playerManager.LedgeClimbState.SetPosition(playerManager.transform.position);
            }
        }

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > startTime + playerData.coyoteTime)
            {
                _coyoteTime = false;
                playerManager.JumpState.DecreaseAmountOfJumps();
            }
        }

        private void CheckJumping() // 用于制作可控的跳跃高度
        {
            if (_isJumping)
            {
                if (playerManager.Rb.velocity.y < 0.01f)
                {
                    _isJumping = false;
                    return;
                }
                
                if (_jumpInputStop)
                {
                    playerManager.SetVelocityY(playerManager.Rb.velocity.y * playerData.variableJumpHeightMultiplier);
                    _isJumping = false;
                    return;
                }
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;

        public void StartJumping() => _isJumping = true;
    }
} 