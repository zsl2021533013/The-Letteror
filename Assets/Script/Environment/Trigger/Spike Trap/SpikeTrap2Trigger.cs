using System;
using Character.Base.Manager;
using Character.Player.Manager;
using Environment.Trigger.Base;
using UnityEngine;

namespace Environment.Trigger
{
    public class SpikeTrap2Trigger : TriggerBase
    {
        [SerializeField] private int attack;

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            manager.BattleManager.Damaged(attack);
        }
    }
}