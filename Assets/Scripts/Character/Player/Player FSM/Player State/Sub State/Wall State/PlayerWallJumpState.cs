using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Wall_State
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        public PlayerWallJumpState(PlayerManager playerManager,
            PlayerData playerData, string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }


        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, -coreManager.MoveCore.Direction);
            coreManager.MoveCore.CheckFlip(playerManager.Input.MovementInput.x);
            playerManager.JumpState.DecreaseAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            playerManager.Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
            playerManager.Anim.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (Time.time > startTime + playerData.wallJumpTime)
            {
                isAbilityDone = true;
            }
        }
    }
}