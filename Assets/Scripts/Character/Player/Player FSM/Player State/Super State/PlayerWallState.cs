using Character.Base.Base_Manager;
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


        public PlayerWallState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
           manager.JumpState.ResetAmountOfJump();
           manager.Input.ResetJumpInput();
           manager.DashState.ResetAmountOfDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            jumpInput =manager.Input.JumpInput;
            
            if (_isGrounded && !grabInput)
            {
                stateMachine.TranslateToState(manager.IdleState);
                return;
            }

            if (_isTouchingWall && jumpInput)
            {
               manager.Input.ResetJumpInput();
                stateMachine.TranslateToState(manager.WallJumpState);
                return;
            }
            
            if (!_isTouchingWall)
            {
                stateMachine.TranslateToState(manager.AirState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = coreManager.SenseCore.DetectGround;
            _isTouchingWall = coreManager.SenseCore.DetectWall;
        }
    }
}