using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State
{
    public class BloodKingBlueChargeState : BloodKingAbilityState
    {
        private int _attackType;

        public BloodKingBlueChargeState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            _attackType = Random.Range(0, 2);

            switch (_attackType)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
    }
}