using System;
using Character.Player.Manager;
using Environment.Trigger.Base;
using Game_Manager;
using UnityEngine;

namespace Environment.Trigger.New_Ability_Trigger.Base
{
    public class NewAbilityBaseTrigger : TriggerBase
    {
        private Animator _animator;
        private static readonly int Disappear = Animator.StringToHash("disappear");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            manager.Input.GainAbility();

            _animator.SetBool(Disappear, true);
        }

        public void OnAnimationFinished()
        {
            Destroy(gameObject);
        }
    }
}