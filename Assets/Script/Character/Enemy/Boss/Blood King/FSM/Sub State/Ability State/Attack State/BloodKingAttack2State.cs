using System;
using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack2State : BloodKingAbilityState
    {
        private bool _isAttackDone;
        
        public BloodKingAttack2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _isAttackDone = false;
        }

        protected override void OnAnimationFinish()
        {
            if (!_isAttackDone)
            {
                manager.HeartAttack();
                _isAttackDone = true;
            }
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Time.time > startTime + 1.6f)
            {
                stateMachine.TranslateToState(manager.IdleState);
            }
        }
    }
}