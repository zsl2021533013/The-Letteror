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

        public void ChangeState(PlayerState playerState)
        {
            CurrentState.OnExit();
            CurrentState = playerState;
            CurrentState.OnEnter();
        }
    }
}
