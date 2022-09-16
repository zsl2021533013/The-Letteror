using PlayerManager.Player_State.Super_State;
using PlayerManager.Data;
using PlayerManager.Player_FSM;
using UnityEngine;

namespace PlayerManager.Player_State.Sub_State
{
    public class PlayerInAirState : PlayerState
    {
        private Vector2 _movementInput;
        private bool _jumpInput;
        private bool _jumpInputStop;
        private bool _grabInput;
        private bool _isJumping;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingLedge;
        private bool _coyoteTime;
        
        public PlayerInAirState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _movementInput = playerManager.Input.MovementInput;
            _jumpInput = playerManager.Input.JumpInput;
            _jumpInputStop = playerManager.Input.JumpInputStop;
            _grabInput = playerManager.Input.GrabInput;
            
            CheckJumping();
            
            playerManager.SetVelocityX(playerData.movementVelocity * _movementInput.x);
            
            playerManager.CheckPlayerFlip();
            
            playerManager.Anim.SetFloat("velocityX", Mathf.Abs(playerManager.Rb.velocity.x));
            playerManager.Anim.SetFloat("velocityY", playerManager.Rb.velocity.y);

            if (_jumpInput && playerManager.JumpState.CheckAmountOfJumps())
            {
                stateMachine.ChangeState(playerManager.JumpState);
                playerManager.Input.UseJumpInput();
                return;
            }

            if (_isTouchingWall && !_isTouchingLedge)
            {
                stateMachine.ChangeState(playerManager.LedgeClimbState);
                return;
            }

            if (_isGrounded && playerManager.Rb.velocity.y < 0.01f)
            {
                stateMachine.ChangeState(playerManager.LandState);
                return;
            }

            if (_isTouchingWall && playerManager.Input.InputDirection == playerManager.PlayerDirection && playerManager.Rb.velocity.y < 0f)
            {
                stateMachine.ChangeState(playerManager.WallSlideState);
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

        private void CheckJumping()
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