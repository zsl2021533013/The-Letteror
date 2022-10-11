
using Character.Base.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State
{
    public class HeartHoarderAbilityState : HeartHoarderState
    {
        protected bool isAbilityDone;
        
        public HeartHoarderAbilityState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            isAbilityDone = false;
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
            
            if (isAbilityDone)
            {
                stateMachine.TranslateToState(manager.IdleState);
                return;
            }
        }

        protected virtual void OnAnimationFinish()
        {
            isAbilityDone = true;
        }
    }
}