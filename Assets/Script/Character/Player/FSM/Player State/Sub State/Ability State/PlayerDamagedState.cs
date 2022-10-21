﻿using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerDamagedState : PlayerAbilityState
    {
        public PlayerDamagedState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}