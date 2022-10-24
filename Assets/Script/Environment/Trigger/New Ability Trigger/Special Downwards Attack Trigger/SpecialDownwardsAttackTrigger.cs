using Character.Player.Manager;
using Environment.Trigger.Base;
using Environment.Trigger.New_Ability_Trigger.Base;
using Game_Manager;
using Script.Game_Manager;
using UnityEngine;

namespace Environment.Trigger.New_Ability_Trigger.Special_Downwards_Attack_Trigger
{
    public class SpecialDownwardsAttackTrigger : NewAbilityBaseTrigger
    {
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            GameManager.Instance.EnableSpecialDownwardsAttack();
        }
    }
}