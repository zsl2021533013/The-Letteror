using System;
using System.Collections;
using Character.Player.FSM.Player_State.Sub_State.Ability_State;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack;
using Character.Player.Manager;
using Environment.Trigger.Base;
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

            if (manager.StateMachine.CurrentState is PlayerDashState or PlayerSpecialDashAttackState)
            {
                _enterTime = Time.time;
            }
        }

        private void Update()
        {
            if (Time.time > _enterTime + 0.5f)
            {
                _collider2D.enabled = true;
            }
            else
            {
                _collider2D.enabled = false;
            }
        }
    }
}