using Character.Base.FSM.Base_State;

namespace Character.Base.FSM.Base_State_Machine
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