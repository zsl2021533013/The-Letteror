using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderHighAppearState : HeartHoarderAbilityState
    {
        public HeartHoarderHighAppearState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.MoveTo(coreManager.MoveCore.MiddlePointPosition);
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack3State);
        }
    }
}