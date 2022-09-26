using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack1StopStopState : HeartHoarderAbilityState
    {
        private Vector2 _startPosition;
        
        public HeartHoarderAttack1StopStopState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition = coreManager.MoveCore.Position; //TODO:不这样写的化会腾一下，真奇怪
            coreManager.MoveCore.Freeze(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.Freeze(_startPosition);
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack1State);
        }
    }
}