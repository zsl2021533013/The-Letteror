using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ground_State
{
    public class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            if (movementInput.x != 0f)
            {
                stateMachine.TranslateToState(manager.MoveState);
            }
            else if(isAnimationFinish)
            {
                stateMachine.TranslateToState(manager.IdleState);
            }
        }
    }
}