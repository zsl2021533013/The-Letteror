using Environment.Trigger.Base;
using Script.Character.Player.Manager;
using UnityEngine;

namespace Environment.Trigger
{
    public class SpikeTrap1Trigger : TriggerBase
    {
        [SerializeField] private Transform resetPosition;
        [SerializeField] private int attack;
        
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            manager.BattleManager.Damaged(attack);
            manager.CoreManager.MoveCore.SetPosition(resetPosition.position);
            manager.CoreManager.MoveCore.SetVelocity(Vector2.zero);
        }
    }
}