using PlayerManager.Data;
using PlayerManager.Player_FSM;
using UnityEngine;

namespace PlayerManager.Player_State.Sub_State
{
    public class PlayerLedgeClimbState : PlayerState
    {
        private Vector2 _detectedPosition;
        private Vector2 _cornerPosition;
        private Vector2 _startPosition;
        private Vector2 _stopPosition;
        private bool _jumpInput;
        
        public PlayerLedgeClimbState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.JumpState.ResetAmountOfJumps();
            
            playerManager.SetVelocity(Vector2.zero);
            playerManager.transform.position = _detectedPosition;
            _cornerPosition = playerManager.DetermineCornerPosition();

            _startPosition.Set(_cornerPosition.x - (playerManager.PlayerDirection * playerData.startOffset.x),
                _cornerPosition.y - playerData.startOffset.y);
            _stopPosition.Set(_cornerPosition.x + (playerManager.PlayerDirection * playerData.startOffset.x),
                _cornerPosition.y + playerData.startOffset.y);

            playerManager.transform.position = _startPosition;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _jumpInput = playerManager.Input.JumpInput;

            playerManager.SetVelocity(Vector2.zero);
            playerManager.transform.position = _startPosition;

            if (_jumpInput)
            {
                stateMachine.ChangeState(playerManager.WallJumpState);
                return;
            }
        }

        public void SetPosition(Vector2 position) => _detectedPosition = position;
    }
}