﻿using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            playerManager.SetVelocityX(playerData.movementVelocity * movementInput.x);
            playerManager.Anim.SetFloat("velocityX", Mathf.Abs(playerManager.Rb.velocity.x));
            
            playerManager.CheckPlayerFlip();
            
            if (Mathf.Abs(movementInput.x) <= 0.1f)
            {
                stateMachine.TranslateToState(playerManager.IdleState);
            }
        }
    }
}