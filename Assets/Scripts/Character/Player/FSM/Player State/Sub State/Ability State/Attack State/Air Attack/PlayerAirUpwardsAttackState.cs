﻿using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Air_Attack
{
    public class PlayerAirUpwardsAttackState : PlayerAttackState
    {
        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.StateMachineData.airAttackCoolDown;
        
        public PlayerAirUpwardsAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.StateMachineData.airUpwardsAttackVelocityY);
            coreManager.MoveCore.FreezeX(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeX(startPosition);
        }
    }
}