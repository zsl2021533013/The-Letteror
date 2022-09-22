using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ground_State
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
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.movementVelocity * movementInput.x);
            manager.Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
           
            coreManager.MoveCore.CheckFlip(manager.Input.MovementInput.x);
            
            if (Mathf.Abs(movementInput.x) <= 0.1f)
            {
                stateMachine.TranslateToState(manager.IdleState);
            }
        }
    }
}