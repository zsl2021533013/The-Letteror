using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;

namespace Character.Player.Player_State.Super_State
{
    public class PlayerWallState : PlayerState
    {
        protected bool grabInput;
        protected bool jumpInput;
        
        private bool _isGrounded;
        protected bool _isTouchingWall;
        
        public PlayerWallState(PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.JumpState.ResetAmountOfJump();
            playerManager.Input.ResetJumpInput();
            playerManager.DashState.ResetAmountOfDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            jumpInput = playerManager.Input.JumpInput;
            
            if (_isGrounded && !grabInput)
            {
                stateMachine.TranslateToState(playerManager.IdleState);
                return;
            }

            if (_isTouchingWall && jumpInput)
            {
                playerManager.Input.ResetJumpInput();
                stateMachine.TranslateToState(playerManager.WallJumpState);
                return;
            }
            
            if (!_isTouchingWall)
            {
                stateMachine.TranslateToState(playerManager.AirState);
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