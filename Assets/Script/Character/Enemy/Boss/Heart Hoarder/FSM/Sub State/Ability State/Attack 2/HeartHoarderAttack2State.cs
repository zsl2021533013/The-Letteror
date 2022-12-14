using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack2State : HeartHoarderAbilityState
    {
        public HeartHoarderAttack2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * coreManager.MoveCore.CharacterDirection);
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack2StopState);
        }
    }
}