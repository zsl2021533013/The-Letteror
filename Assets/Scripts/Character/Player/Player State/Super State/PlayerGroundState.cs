using PlayerManager.Data;
using PlayerManager.Player_FSM;
using UnityEngine;

namespace PlayerManager.Player_State.Super_State
{
    public class PlayerGroundState : PlayerState
    {
        protected Vector2 movementInput;

        private bool _jumpInput;
        private bool _grabInput;
        private bool _isGrounded;
        private bool _isTouchingWall;
        
        public PlayerGroundState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            playerManager.Input.UseJumpInput();
            playerManager.JumpState.ResetAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            movementInput = playerManager.Input.MovementInput;
            _jumpInput = playerManager.Input.JumpInput;
            _grabInput = playerManager.Input.GrabInput;
            
            if (_jumpInput && playerManager.JumpState.CheckAmountOfJumps())
            {
                playerManager.Input.UseJumpInput();
                stateMachine.ChangeState(playerManager.JumpState);
                return;
            }

            if (!_isGrounded)
            {
                playerManager.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(playerManager.InAirState);
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