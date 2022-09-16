using Character.Player.Data;
using Character.Player.Player_FSM;
using UnityEngine;

namespace Character.Player.Player_State.Super_State
{
    public class PlayerTouchingWallState : PlayerState
    {
        protected bool grabInput;
        protected bool jumpInput;
        
        private bool _isGrounded;
        protected bool _isTouchingWall;
        
        public PlayerTouchingWallState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.JumpState.ResetAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            grabInput = playerManager.Input.GrabInput;
            jumpInput = playerManager.Input.JumpInput;
            
            if (_isGrounded && !grabInput)
            {
                stateMachine.ChangeState(playerManager.IdleState);
                return;
            }

            if (_isTouchingWall && jumpInput)
            {
                playerManager.Input.UseJumpInput();
                stateMachine.ChangeState(playerManager.WallJumpState);
                return;
            }
            
            if (!_isTouchingWall)
            {
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