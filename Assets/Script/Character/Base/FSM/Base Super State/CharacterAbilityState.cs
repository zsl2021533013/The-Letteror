using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using UnityEngine;

namespace Character.Base.FSM.Base_Super_State
{
    public class CharacterAbilityState : CharacterState
    {
        protected bool isAbilityDone;

        private bool isGrounded;
        
        public CharacterAbilityState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
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

            if (isAnimationFinish)
            {
                OnAnimationFinish();
            }
            
            if (isAbilityDone)
            {
                OnAbilityDone();
            }
        }

        protected virtual void OnAnimationFinish()
        {
            isAbilityDone = true;
        }

        protected virtual void OnAbilityDone()
        {
        }
    }
}