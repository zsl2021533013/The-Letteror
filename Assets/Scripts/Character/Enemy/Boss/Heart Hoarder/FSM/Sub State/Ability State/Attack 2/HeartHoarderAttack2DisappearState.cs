using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack2DisappearState : HeartHoarderAbilityState
    {
        public HeartHoarderAttack2DisappearState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.LowAppearState);
        }
    }
}