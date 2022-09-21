namespace Character.Player.Player_FSM
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set; }

        public void Initialize(PlayerState playerState)
        {
            CurrentState = playerState;
            CurrentState.OnEnter();
        }

        public void TranslateToState(PlayerState playerState)
        {
            if (CurrentState.IsStateFinished)
            {
                return;
            }
            CurrentState.OnExit();
            CurrentState = playerState;
            CurrentState.OnEnter();
        }
    }
}
