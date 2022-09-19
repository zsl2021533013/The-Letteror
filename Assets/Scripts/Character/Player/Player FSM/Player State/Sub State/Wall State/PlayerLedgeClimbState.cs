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
        
        public PlayerLedgeClimbState(PlayerManager playerManager, PlayerData playerData,
            string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.JumpState.ResetAmountOfJump();
            
            playerManager.transform.position = _detectedPosition;
            _cornerPosition = coreManager.SenseCore.GetCornerPosition();

            SetStartPosition();

            coreManager.MoveCore.Freeze(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _jumpInput = playerManager.Input.JumpInput;

            coreManager.MoveCore.Freeze(_startPosition);

            if (_jumpInput)
            {
                stateMachine.TranslateToState(playerManager.WallJumpState);
                return;
            }
        }

        public void SetPosition(Vector2 position) => _detectedPosition = position;

        private void SetStartPosition()
        {
            _startPosition.Set(_cornerPosition.x - (coreManager.MoveCore.Direction * playerData.startOffset.x),
                _cornerPosition.y - playerData.startOffset.y);
            _stopPosition.Set(_cornerPosition.x + (coreManager.MoveCore.Direction * playerData.startOffset.x),
                _cornerPosition.y + playerData.startOffset.y);
        }
    }
}