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
        private bool _rollInput;
        private bool _isGrounded;
        
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
            _rollInput = playerManager.Input.RollInput;
            
            if (_jumpInput && playerManager.JumpState.CheckAmountOfJump())
            {
                playerManager.Input.ResetJumpInput();
                stateMachine.TranslateToState(playerManager.JumpState);
                return;
            }

            if (_dashInput && playerManager.DashState.CheckAmountOfDash())
            {
                playerManager.Input.ResetDashInput();
                stateMachine.TranslateToState(playerManager.DashState);
                return;
            }
            
            if (!_isGrounded)
            {
                playerManager.AirState.StartCoyoteTime();
                stateMachine.TranslateToState(playerManager.AirState);
                return;
            }
            
            if (_rollInput)
            {
                playerManager.Input.ResetRollInput();
                stateMachine.TranslateToState(playerManager.RollState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = playerManager.CheckGrounded();
        }
    }
}