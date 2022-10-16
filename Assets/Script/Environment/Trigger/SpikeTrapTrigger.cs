using Character.Player.Manager;
using Environment.Trigger.Base;
using UnityEngine;

namespace Environment.Trigger
{
    public class SpikeTrapTrigger : TriggerBase
    {
        [SerializeField] private int attack;
        [SerializeField] private Vector2 returnOffset;
        
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            manager.BattleManager.Damaged(attack);
            manager.CoreManager.MoveCore.SetPosition(manager.FormerOnGroundPosition + returnOffset);
        }
    }
}