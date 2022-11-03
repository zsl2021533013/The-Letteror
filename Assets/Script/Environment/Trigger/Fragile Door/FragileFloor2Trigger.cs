using System;
using System.Collections;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack;
using Environment.Trigger.Base;
using Script.Character.Player.Manager;
using UnityEngine;

namespace Environment.Trigger
{
    public class FragileFloor2Trigger : TriggerBase
    {
        [SerializeField] private float _destroyedPauseTime;
        
        private BoxCollider2D _boxCollider2D;
        private Animator _animator;
        private static readonly int Disappear = Animator.StringToHash("disappear");

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _animator = GetComponent<Animator>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            if (manager.StateMachine.CurrentState is PlayerSpecialDownwardsAttack2State)
            {
                _animator.SetBool(Disappear, true);
                manager.CoreManager.BattleEffectCore.StopForSeconds(_destroyedPauseTime);
            }

            if (manager.StateMachine.CurrentState is PlayerSpecialUpwardsAttackState)
            {
                _animator.SetBool(Disappear, true);
                _boxCollider2D.enabled = false;
                manager.CoreManager.BattleEffectCore.StopForSeconds(_destroyedPauseTime);
            }
        }

        public void OnAnimationFinish()
        {
            Destroy(gameObject);
        }
    }
}