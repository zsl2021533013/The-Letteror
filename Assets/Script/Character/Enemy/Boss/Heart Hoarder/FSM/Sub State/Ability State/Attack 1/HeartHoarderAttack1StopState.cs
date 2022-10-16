using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack1StopState : HeartHoarderAbilityState
    {
        private Vector2 _startPosition;
        
        public HeartHoarderAttack1StopState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.SetVelocityX(0f);
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack1State);
        }
    }
}