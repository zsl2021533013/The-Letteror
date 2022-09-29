using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State
{
    public class BloodKingChargeState : BloodKingAbilityState
    {
        private int _attackType;
        
        public BloodKingChargeState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            _attackType = Random.Range(1, 2);

            switch (_attackType)
            {
                case 0:
                    stateMachine.TranslateToState(manager.Attack1State);
                    break;
                case 1:
                    stateMachine.TranslateToState(manager.Attack4_1State);
                    break;
            }
        }
    }
}