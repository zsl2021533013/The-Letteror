using UnityEngine;

namespace Character.Enemy.Enemy_FSM
{
    public class EnemyStateMachine
    {
        public EnemyState CurrentState { get; private set; }

        public void Initialize(EnemyState playerState)
        {
            CurrentState = playerState;
            CurrentState.OnEnter();
        }

        public void TranslateToState(EnemyState playerState)
        {
            CurrentState.OnExit();
            CurrentState = playerState;
            CurrentState.OnEnter();
        }
    }
}
