using Character.Base.Manager;
using Character.Enemy.FSM;

namespace Character.Enemy.Base.FSM.Enemy_State.Super_State
{
    public class EnemyAbilityState : EnemyState
    {
        protected bool isAbilityDone;
        
        public EnemyAbilityState(CharacterManager manager, string animBoolName) : base(manager,
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