using Character.Core.Core_Component;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(PlayerManager playerManager, PlayerData playerData,
            string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (IsStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.SetVelocityX(playerData.movementVelocity * movementInput.x);
            playerManager.Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
            
            if (!(coreManager.MoveCore as PlayerMoveCore))
            {
                Debug.LogError("Missing Player Move Core");
            }
            (coreManager.MoveCore as PlayerMoveCore).CheckFlip(playerManager.Input.MovementInput.x);
            
            if (Mathf.Abs(movementInput.x) <= 0.1f)
            {
                stateMachine.TranslateToState(playerManager.IdleState);
            }
        }
    }
}