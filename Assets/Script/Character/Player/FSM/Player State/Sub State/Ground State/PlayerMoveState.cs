using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ground_State
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * movementInput.x);
            manager.AnimationManager.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
           
            coreManager.MoveCore.CheckFlip(manager.Input);
            
            if (Mathf.Abs(movementInput.x) <= 0.1f)
            {
                stateMachine.TranslateToState(manager.IdleState);
            }
        }
    }
}