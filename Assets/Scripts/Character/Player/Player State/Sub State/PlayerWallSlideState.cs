using PlayerManager.Data;
using PlayerManager.Player_FSM;
using PlayerManager.Player_State.Super_State;
using UnityEngine;

namespace PlayerManager.Player_State.Sub_State
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
        }
    }
}