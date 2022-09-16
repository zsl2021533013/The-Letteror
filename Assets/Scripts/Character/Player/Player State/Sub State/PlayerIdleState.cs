using Character.Player.Data;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (movementInput.x != 0f)
            {
                stateMachine.ChangeState(playerManager.MoveState);
            }
        }
    }
}