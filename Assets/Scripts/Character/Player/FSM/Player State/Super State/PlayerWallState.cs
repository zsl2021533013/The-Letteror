using Character.Base.Manager;
using Character.Player.Input_System;

namespace Character.Player.FSM.Player_State.Super_State
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

            ResetTriggers(manager.Input);
            manager.ResetJumpAndDash();
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

        private void ResetTriggers(PlayerInputHandler input)
        {
            input.ResetJumpInput();
            input.ResetDashInput();
            input.ResetSpecialDashInput();
            input.ResetAttackInput();
            input.ResetSpecialAttackInput();
        }
    }
}