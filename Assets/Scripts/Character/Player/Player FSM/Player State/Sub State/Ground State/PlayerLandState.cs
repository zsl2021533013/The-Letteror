using Character.Base.Base_Manager;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (movementInput.x != 0f)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).MoveState);
            }
            else if(isAnimationFinish)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).IdleState);
            }
        }
    }
}