using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Base_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Super_State
{
    public class ColossalBossAbilityState : ColossalBossState
    {
        public ColossalBossAbilityState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
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