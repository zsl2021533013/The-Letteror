using Character.Player.Data;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State
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
            
            playerManager.Anim.SetFloat("velocityY", playerManager.Rb.velocity.y);

            if (_jumpInput && playerManager.JumpState.CheckAmountOfJumps())
            {
                stateMachine.ChangeState(playerManager.JumpState);
                return;
            }

            if (_isGrounded && playerManager.Rb.velocity.y < 0.01f)
            {
                stateMachine.ChangeState(playerManager.LandState);
                return;
            }

            if (_jumpInput && _isTouchingWall)
            {
                stateMachine.ChangeState(playerManager.WallJumpState);
                return;
            }
            
            if (_isTouchingWall && _grabInput)
            {
                stateMachine.ChangeState(playerManager.WallGrabState);
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