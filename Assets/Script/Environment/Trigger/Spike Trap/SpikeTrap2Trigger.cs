using System;
using Character.Base.Manager;
using Environment.Trigger.Base;
using Script.Character.Player.Manager;
using UnityEngine;

namespace Environment.Trigger
{
    public class SpikeTrap2Trigger : TriggerBase
    {
        [SerializeField] private int attack;
        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            manager.BattleManager.Damaged(attack);
            _boxCollider2D.enabled = false;
        }

        public void EnableCollider()
        {
            _boxCollider2D.enabled = true;
        }

        public void DisableCollider()
        {
            _boxCollider2D.enabled = false;
        }
    }
}