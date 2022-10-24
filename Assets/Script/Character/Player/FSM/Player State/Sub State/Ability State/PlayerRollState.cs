﻿using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerRollState : PlayerAbilityState
    {
        public PlayerRollState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            manager.BattleManager.StartImmortal();
            
            coreManager.MoveCore.SetVelocityY(0f);
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.rollVelocity * coreManager.MoveCore.CharacterDirection);
        }

        public override void OnExit()
        {
            base.OnExit();
            
            manager.BattleManager.EndImmortal();
        }
    }
}