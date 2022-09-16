using Character.Player.Data;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State
{
    public class PlayerWallGrabState : PlayerTouchingWallState
    {
        private Vector2 _holdPosition;
        
        public PlayerWallGrabState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _holdPosition = playerManager.transform.position;
            
            HoldPosition();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            HoldPosition();

            if(playerManager.Input.MovementInput.y < 0f || !grabInput)
            {
                stateMachine.ChangeState(playerManager.WallSlideState);
                return;
            }
        }

        private void HoldPosition()
        {
            playerManager.transform.position = _holdPosition;
            
            playerManager.SetVelocityX(0f);
            playerManager.SetVelocityY(0f);
        }
    }
}