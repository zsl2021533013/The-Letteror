using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(PlayerManager playerManager,  PlayerData playerData,
            string animBoolName) : base(playerManager, playerData, animBoolName)
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
            
            if (IsStateFinished)
            {
                return;
            }
            
            if (movementInput.x != 0f)
            {
                stateMachine.TranslateToState(playerManager.MoveState);
            }
        }
    }
}