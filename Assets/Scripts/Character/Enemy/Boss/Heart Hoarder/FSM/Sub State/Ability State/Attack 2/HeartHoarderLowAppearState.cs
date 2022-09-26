﻿using Character.Base.Core.Core_Component;
using Character.Base.Manager;
using Character.Enemy.Base.FSM.Enemy_State.Super_State;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderLowAppearState : HeartHoarderAbilityState
    {
        private int _attackType;
        
        public HeartHoarderLowAppearState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _attackType = Random.Range(0, 2);

            switch (_attackType)
            {
                case 0:
                    coreManager.MoveCore.MoveTo(coreManager.MoveCore.LeftPointPosition);
                    coreManager.CharacterTransform.localScale = new Vector3(1, 1, 1);
                    break;
                case 1:
                    coreManager.MoveCore.MoveTo(coreManager.MoveCore.RightPointPosition);
                    coreManager.CharacterTransform.localScale = new Vector3(-1, 1, 1);
                    break;
            }
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack2PrepareState);
        }
    }
}