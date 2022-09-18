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
            _cornerPosition = DetermineCornerPosition();

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
        
        private Vector2 DetermineCornerPosition()
        {
            RaycastHit2D hitX = Physics2D.Raycast(coreManager.SenseCore.WallSensor.position,
                Vector2.right * coreManager.MoveCore.Direction, playerData.wallCheckDistance,
                playerData.groundLayerMask);
            float distanceX = hitX.distance + 0.01f;

            Vector2 detectPosition = (Vector2)coreManager.SenseCore.LedgeSensor.position +
                                     new Vector2(distanceX * coreManager.MoveCore.Direction, 0f);
            float detectDistance = coreManager.SenseCore.LedgeSensor.position.y - coreManager.SenseCore.WallSensor.position.y;
            RaycastHit2D hitY = Physics2D.Raycast(detectPosition, Vector2.down,
                detectDistance, playerData.groundLayerMask);
            float distanceY = hitY.distance + 0.01f;

            return new Vector2(coreManager.SenseCore.WallSensor.position.x + distanceX * coreManager.MoveCore.Direction,
                coreManager.SenseCore.LedgeSensor.position.y - distanceY);
        }
    }
}