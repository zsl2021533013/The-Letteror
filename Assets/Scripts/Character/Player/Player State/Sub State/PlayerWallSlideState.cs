using Character.Player.Data;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        public PlayerWallSlideState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            playerManager.SetVelocityY(-playerData.wallSlideVelocity);

            if (grabInput && playerManager.Input.MovementInput.y >= 0f)
            {
                stateMachine.ChangeState(playerManager.WallGrabState);
                return;
            }
            
        }
    }
}