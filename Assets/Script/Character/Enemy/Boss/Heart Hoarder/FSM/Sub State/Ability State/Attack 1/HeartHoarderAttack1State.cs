using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack1State : HeartHoarderAbilityState
    {
        public HeartHoarderAttack1State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack1GetUpState);
        }
    }
}