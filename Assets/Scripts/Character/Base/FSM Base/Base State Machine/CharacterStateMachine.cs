using Character.Base.FSM_Base.Base_State;
using UnityEngine;

namespace Character.Base.FSM_Base.Base_State_Machine
{
    public class CharacterStateMachine
    {
        public CharacterState CurrentState { get; private set; }

        public void Initialize(CharacterState characterState)
        {
            CurrentState = characterState;
            CurrentState.OnEnter();
        }

        public void TranslateToState(CharacterState characterState)
        {
            CurrentState.OnExit();
            CurrentState = characterState;
            CurrentState.OnEnter();
        }
    }
}