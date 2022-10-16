using System;
using System.Collections;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack;
using Character.Player.Manager;
using Environment.Trigger.Base;
using UnityEngine;

namespace Environment.Trigger
{
    public class FragileFloorTrigger : TriggerBase
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            if (manager.StateMachine.CurrentState is PlayerSpecialDownwardsAttack2State or PlayerSpecialUpwardsAttackState)
            {
                _animator.SetBool("disappear", true);
            }
        }

        public void OnAnimationFinish()
        {
            Destroy(gameObject);
        }
    }
}