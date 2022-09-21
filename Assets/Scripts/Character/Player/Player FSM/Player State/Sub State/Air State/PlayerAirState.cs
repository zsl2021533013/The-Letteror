using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Air_State
{
    public class PlayerAirState : PlayerState
    {
        private Vector2 _movementInput;
        private bool _jumpInput;
        private bool _jumpInputStop;
        private bool _dashInput;
        private bool _attackInput;
        private bool _isJumping;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingLedge;
        private bool _coyoteTime;


        public PlayerAirState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            ((PlayerManager)characterManager).Input.ResetDashInput();
            ((PlayerManager)characterManager).Input.ResetAttackInput();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _movementInput = ((PlayerManager)characterManager).Input.MovementInput;
            _jumpInput = ((PlayerManager)characterManager).Input.JumpInput;
            _jumpInputStop = ((PlayerManager)characterManager).Input.JumpInputStop;
            _dashInput = ((PlayerManager)characterManager).Input.DashInput;
            _attackInput = ((PlayerManager)characterManager).Input.AttackInput;
            
            CheckJumping();
            
            coreManager.MoveCore.SetVelocityX(((PlayerMoveCore)coreManager.MoveCore).PlayerData.movementVelocity * _movementInput.x);
            ((PlayerMoveCore)coreManager.MoveCore).CheckFlip(((PlayerManager)characterManager).Input.MovementInput.x);
            
            ((PlayerManager)characterManager).Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
            ((PlayerManager)characterManager).Anim.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (_jumpInput && ((PlayerManager)characterManager).JumpState.CheckAmountOfJump())
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).JumpState);
                ((PlayerManager)characterManager).Input.ResetJumpInput();
                return;
            }
            
            if (((PlayerManager)characterManager).isDashEnable && _dashInput && ((PlayerManager)characterManager).DashState.CheckAmountOfDash())
            {
                ((PlayerManager)characterManager).Input.ResetDashInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).DashState);
                return;
            }

            if (_attackInput)
            {
                ((PlayerManager)characterManager).Input.ResetAttackInput();
                stateMachine.TranslateToState(((PlayerManager)characterManager).Attack1State);
                return;
            }

            if (_isGrounded && coreManager.MoveCore.CurrentVelocity.y < 0.01f)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).LandState);
                return;
            }
            
            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).LedgeClimbState);
                return;
            }

            if (((PlayerManager)characterManager).isWallSlideEnable && _isTouchingWall && ((PlayerManager)characterManager).Input.InputDirection == coreManager.MoveCore.Direction &&
                coreManager.MoveCore.CurrentVelocity.y < 0.1f) 
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).WallSlideState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            CheckCoyoteTime();
            
            _isGrounded = coreManager.SenseCore.DetectGround;
            _isTouchingWall = coreManager.SenseCore.DetectWall;
            _isTouchingLedge = coreManager.SenseCore.DetectLedge;
            
            if (_isTouchingWall && !_isTouchingLedge)
            {
                ((PlayerManager)characterManager).LedgeClimbState.SetPosition(((PlayerManager)characterManager).transform.position);
            }
        }

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > startTime + ((PlayerMoveCore)coreManager.MoveCore).PlayerData.coyoteTime)
            {
                _coyoteTime = false;
                ((PlayerManager)characterManager).JumpState.DecreaseAmountOfJumps();
            }
        }

        private void CheckJumping() // 用于制作可控的跳跃高度
        {
            if (_isJumping)
            {
                if (coreManager.MoveCore.CurrentVelocity.y < 0.01f)
                {
                    _isJumping = false;
                    return;
                }
                
                if (_jumpInputStop)
                {
                    coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.CurrentVelocity.y * ((PlayerMoveCore)coreManager.MoveCore).PlayerData.variableJumpHeightMultiplier);
                    _isJumping = false;
                    return;
                }
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;

        public void StartJumping() => _isJumping = true;
    }
} 