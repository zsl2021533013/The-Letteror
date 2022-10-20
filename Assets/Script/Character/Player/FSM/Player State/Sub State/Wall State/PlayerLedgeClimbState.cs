using Character.Base.Manager;
using Character.Player.Core.Core_Component;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Wall_State
{
    public class PlayerLedgeClimbState : PlayerState
    {
        private PlayerInputDirectionType _inputDirectionType;
        private Vector2 _detectedPosition;
        private Vector2 _cornerPosition;
        private Vector2 _startPosition;
        private Vector2 _stopPosition;
        private bool _jumpInput;

        public PlayerLedgeClimbState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            ResetTriggers(manager.Input);
            
            manager.ResetJumpAndDash();
            
            manager.transform.position = _detectedPosition;
            
            _cornerPosition = coreManager.SenseCore.GetCornerPosition();

            SetStartPosition();

            coreManager.MoveCore.Freeze(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.Freeze(_startPosition);

            if (_jumpInput)
            {
                stateMachine.TranslateToState(manager.WallJumpState);
                return;
            }

            if (_inputDirectionType == PlayerInputDirectionType.Down)
            {
                stateMachine.TranslateToState(manager.AirState);
                return;
            }
        }

        public void SetPosition(Vector2 position) => _detectedPosition = position;

        private void SetStartPosition()
        {
            _startPosition.Set(_cornerPosition.x - (coreManager.MoveCore.CharacterDirection * coreManager.MoveCore.StateMachineData.startOffset.x),
                _cornerPosition.y - coreManager.MoveCore.StateMachineData.startOffset.y);
            _stopPosition.Set(_cornerPosition.x + (coreManager.MoveCore.CharacterDirection * coreManager.MoveCore.StateMachineData.startOffset.x),
                _cornerPosition.y + coreManager.MoveCore.StateMachineData.startOffset.y);
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            base.UpdateInput(input);

            _inputDirectionType = input.InputDirectionType;
            _jumpInput = manager.Input.JumpInput;
        }

        private void ResetTriggers(PlayerInputHandler input)
        {
            input.ResetJumpInput();
            input.ResetDashInput();
            input.ResetAttackInput();
            input.ResetSpecialAttackInput();
        }
    }
}