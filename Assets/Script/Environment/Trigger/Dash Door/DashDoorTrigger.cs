using System;
using System.Collections;
using Character.Player.FSM.Player_State.Sub_State.Ability_State;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack;
using Environment.Trigger.Base;
using Script.Character.Player.FSM.Player_State.Sub_State.Ability_State;
using Script.Character.Player.Manager;
using UnityEngine;

namespace Environment.Trigger
{
    public class DashDoorTrigger : TriggerBase
    {
        private float _enterTime;
        private Animator _animator;
        private BoxCollider2D _collider2D;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<BoxCollider2D>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            if (manager.StateMachine.CurrentState is PlayerDashState)
            {
                manager.CoreManager.MoveCore.DisableCollisionForSeconds(_collider2D);
            }
        }
    }
}