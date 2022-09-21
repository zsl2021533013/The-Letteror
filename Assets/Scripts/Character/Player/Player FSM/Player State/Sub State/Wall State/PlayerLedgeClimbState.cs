using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Wall_State
{
    public class PlayerLedgeClimbState : PlayerState
    {
        private Vector2 _detectedPosition;
        private Vector2 _cornerPosition;
        private Vector2 _startPosition;
        private Vector2 _stopPosition;
        private bool _jumpInput;

        public PlayerLedgeClimbState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            ((PlayerManager)characterManager).JumpState.ResetAmountOfJump();
            
            ((PlayerManager)characterManager).transform.position = _detectedPosition;
            
            _cornerPosition = (coreManager.SenseCore as PlayerSenseCore).GetCornerPosition();

            SetStartPosition();

            coreManager.MoveCore.Freeze(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _jumpInput = ((PlayerManager)characterManager).Input.JumpInput;

            coreManager.MoveCore.Freeze(_startPosition);

            if (_jumpInput)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).WallJumpState);
                return;
            }
        }

        public void SetPosition(Vector2 position) => _detectedPosition = position;

        private void SetStartPosition()
        {
            _startPosition.Set(_cornerPosition.x - (coreManager.MoveCore.Direction * ((PlayerMoveCore)coreManager.MoveCore).PlayerData.startOffset.x),
                _cornerPosition.y - ((PlayerMoveCore)coreManager.MoveCore).PlayerData.startOffset.y);
            _stopPosition.Set(_cornerPosition.x + (coreManager.MoveCore.Direction * ((PlayerMoveCore)coreManager.MoveCore).PlayerData.startOffset.x),
                _cornerPosition.y + ((PlayerMoveCore)coreManager.MoveCore).PlayerData.startOffset.y);
        }
    }
}