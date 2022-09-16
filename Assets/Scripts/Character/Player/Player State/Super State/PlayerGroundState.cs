using Character.Player.Data;
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
        private bool _grabInput;
        private bool _isGrounded;
        private bool _isTouchingWall;
        
        public PlayerGroundState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            playerManager.Input.ResetJumpInput();
            playerManager.Input.ResetDashInput();
            playerManager.JumpState.ResetAmountOfJump();
            playerManager.DashState.ResetAmountOfDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            movementInput = playerManager.Input.MovementInput;
            _jumpInput = playerManager.Input.JumpInput;
            _dashInput = playerManager.Input.DashInput;
            
            if (_jumpInput && playerManager.JumpState.CheckAmountOfJump())
            {
                playerManager.Input.ResetJumpInput();
                stateMachine.ChangeState(playerManager.JumpState);
                return;
            }

            if (_dashInput && playerManager.DashState.CheckAmountOfDash())
            {
                playerManager.Input.ResetDashInput();
                stateMachine.ChangeState(playerManager.DashState);
                return;
            }

            if (!_isGrounded)
            {
                playerManager.AirState.StartCoyoteTime();
                stateMachine.ChangeState(playerManager.AirState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = playerManager.CheckGrounded();
            _isTouchingWall = playerManager.CheckWall();
        }
    }
}