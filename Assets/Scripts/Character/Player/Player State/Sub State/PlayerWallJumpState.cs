using PlayerManager.Data;
using PlayerManager.Player_FSM;
using PlayerManager.Player_State.Super_State;
using UnityEngine;

namespace PlayerManager.Player_State.Sub_State
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        public PlayerWallJumpState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }


        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, -playerManager.PlayerDirection);
            playerManager.CheckPlayerFlip();
            playerManager.JumpState.DecreaseAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            playerManager.Anim.SetFloat("velocityX", Mathf.Abs(playerManager.Rb.velocity.x));
            playerManager.Anim.SetFloat("velocityY", playerManager.Rb.velocity.y);

            if (Time.time > startTime + playerData.wallJumpTime)
            {
                isAbilityDone = true;
            }
        }
    }
}