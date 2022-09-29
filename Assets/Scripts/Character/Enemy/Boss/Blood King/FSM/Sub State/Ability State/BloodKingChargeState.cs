using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State
{
    public class BloodKingChargeState : BloodKingAbilityState
    {
        
        public BloodKingChargeState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack4_1State);
        }
    }
}