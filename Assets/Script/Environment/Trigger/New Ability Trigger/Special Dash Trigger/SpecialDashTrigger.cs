﻿using Character.Player.Manager;
using Environment.Trigger.New_Ability_Trigger.Base;
using Game_Manager;
using UnityEngine;

namespace Environment.Trigger.New_Ability_Trigger.Special_Dash_Trigger
{
    public class SpecialDashTrigger : NewAbilityBaseTrigger
    {
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            GameManager.Instance.EnableSpecialDash();
        }
    }
}