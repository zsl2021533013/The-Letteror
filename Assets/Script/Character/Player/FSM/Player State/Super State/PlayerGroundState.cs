using Character.Base.Manager;
using Script.Character.Player.Input_System;
using UnityEngine;

namespace Script.Character.Player.FSM.Player_State.Super_State
{
    public class PlayerGroundState : PlayerState
    {
        protected Vector2 movementInput;

        private bool _jumpInput;
        private bool _dashInput;
        private bool _attackInput;
        private bool _specialAttackInput;
        private bool _gainAbility;
        
        private bool _isGrounded;
        private bool _isDetectNPC;
        
        private PlayerInputDirectionType _inputDirectionType;
        private Collider2D _oneWayPlatformCollider;
        
        public PlayerGroundState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

           ResetTriggers(manager.Input);
           manager.ResetAbility();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
         
            if (isStateFinished)
            {
                return;
            }

            if (_gainAbility)
            {
                manager.Input.ResetGainAbility();
                stateMachine.TranslateToState(manager.GainAbilityState);
                return;
            }
            
            if (_attackInput)
            {
                CheckGroundAttack();
                return;
            }
            
            if (_specialAttackInput)
            {
                CheckSpecialAttack();
                return;
            }

            if (_inputDirectionType == PlayerInputDirectionType.Down && _oneWayPlatformCollider)
            {
                coreManager.MoveCore.DisableCollisionForSeconds(_oneWayPlatformCollider);
            }

            switch (_jumpInput)
            {
                case true when _isDetectNPC:
                    break;
                case true when manager.JumpState.CheckAmountOfJump():
                    manager.Input.ResetJumpInput();
                    stateMachine.TranslateToState(manager.JumpState);
                    return;
            }

            if (manager.AbilityData.isDashEnable && _dashInput &&manager.DashState.CheckAmountOfDash())
            {
                manager.Input.ResetDashInput();
                stateMachine.TranslateToState(manager.DashState);
                return;
            }

            if (!_isGrounded)
            {
                manager.AirState.StartCoyoteTime();
                stateMachine.TranslateToState(manager.AirState);
                return;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            
            manager.UpdateFormerPosition(coreManager.MoveCore.Position);
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = coreManager.SenseCore.DetectGround;
            _isDetectNPC = coreManager.SenseCore.DetectNPC;
            _oneWayPlatformCollider = coreManager.SenseCore.DetectOneWayPlatform;
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            movementInput = input.MovementInput;
            _jumpInput = input.JumpInput;
            _dashInput = input.DashInput;
            _attackInput = input.AttackInput;
            _specialAttackInput = input.SpecialAttackInput;
            _inputDirectionType = input.InputDirectionType;
            _gainAbility = input.IsGainAbility;
        }

        private void ResetTriggers(PlayerInputHandler input)
        {
            input.ResetJumpInput();
            input.ResetDashInput();
            input.ResetSpecialDashInput();
            input.ResetAttackInput();
            input.ResetSpecialAttackInput();
        }
        
        private void CheckGroundAttack()
        {
            manager.Input.ResetAttackInput();
            switch (manager.Input.InputDirectionType)
            {
                case PlayerInputDirectionType.Up:
                    stateMachine.TranslateToState(manager.GroundUpwardsAttackState);
                    break;
                default:
                    stateMachine.TranslateToState(manager.GroundAttack1State);
                    break;
            }
        }
        
        private void CheckSpecialAttack()
        {
            manager.Input.ResetSpecialAttackInput();
            
            switch (manager.Input.InputDirectionType)
            {
                case PlayerInputDirectionType.Up when manager.AbilityData.isSpecialUpwardsAttackEnable:
                    if (manager.SpecialUpwardsAttackState.CheckAmountOfSpecialAttack())
                    {
                        stateMachine.TranslateToState(manager.SpecialUpwardsAttackState);
                    }
                    break;
                case PlayerInputDirectionType.Left when manager.AbilityData.isSpecialHorizontalAttackEnable:
                    if (manager.SpecialDashAttackState.CheckAmountOfSpecialAttack())
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                case PlayerInputDirectionType.Right when manager.AbilityData.isSpecialHorizontalAttackEnable:
                    if (manager.SpecialDashAttackState.CheckAmountOfSpecialAttack())
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                case PlayerInputDirectionType.None when manager.AbilityData.isSpecialHorizontalAttackEnable:
                    if (manager.SpecialDashAttackState.CheckAmountOfSpecialAttack())
                    {
                        stateMachine.TranslateToState(manager.SpecialDashAttackState);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}