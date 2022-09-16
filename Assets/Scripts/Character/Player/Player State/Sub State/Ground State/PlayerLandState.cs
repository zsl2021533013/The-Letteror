using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (movementInput.x != 0f)
            {
                stateMachine.TranslateToState(playerManager.MoveState);
            }
            else if(isAnimationFinished)
            {
                stateMachine.TranslateToState(playerManager.IdleState);
            }
        }
    }
}