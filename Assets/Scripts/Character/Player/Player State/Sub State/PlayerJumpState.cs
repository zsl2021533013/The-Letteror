using Character.Player.Data;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int amountOfJumpsLeft;
        
        public PlayerJumpState(Player_FSM.PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
            amountOfJumpsLeft = playerData.amountOfJumps;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.SetVelocityY(playerData.jumpVelocity);
            isAbilityDone = true;
            DecreaseAmountOfJumps();
            playerManager.InAirState.StartJumping();
            playerManager.Input.UseJumpInput();
        }
        
        public bool CheckAmountOfJumps() => amountOfJumpsLeft > 0;

        public void ResetAmountOfJumps() => amountOfJumpsLeft = playerData.amountOfJumps;

        public void DecreaseAmountOfJumps() => --amountOfJumpsLeft;

    }
}