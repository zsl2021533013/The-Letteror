using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ability_State
{
    public class ColossalBossTurnState : ColossalBossAbilityState
    {
        private CharacterState _formerState;
        
        public ColossalBossTurnState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            coreManager.MoveCore.Flip();
            stateMachine.TranslateToState(_formerState);
        }

        public void SetFormerState(CharacterState formerState) => _formerState = formerState;
    }
}