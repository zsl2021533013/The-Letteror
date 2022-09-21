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


        public PlayerWallState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            ((PlayerManager)characterManager).JumpState.ResetAmountOfJump();
            ((PlayerManager)characterManager).Input.ResetJumpInput();
            ((PlayerManager)characterManager).DashState.ResetAmountOfDash();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            jumpInput = ((PlayerManager)characterManager).Input.JumpInput;
            
            if (_isGrounded && !grabInput)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).IdleState);
                return;
            }

            if (_isTouchingWall && jumpInput)
            {
                ((PlayerManager)characterManager).Input.ResetJumpInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).WallJumpState);
                return;
            }
            
            if (!_isTouchingWall)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).AirState);
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