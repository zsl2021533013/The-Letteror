﻿using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Wall_State
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        public PlayerWallJumpState(PlayerManager playerManager, PlayerStateMachine stateMachine,
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