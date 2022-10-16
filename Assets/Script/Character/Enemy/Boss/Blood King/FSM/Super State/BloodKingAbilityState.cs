using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Super_State
{
    public class BloodKingAbilityState : BloodKingState
    {
        protected BloodKingAbilityState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            if (isAnimationFinish)
            {
                OnAnimationFinish();
            }
        }

        protected virtual void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.IdleState);
        }
    }
}