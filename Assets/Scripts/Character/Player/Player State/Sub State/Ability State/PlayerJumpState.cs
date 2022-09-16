using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ability_State
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int _amountOfJumpsLeft;
        
        public PlayerJumpState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
            _amountOfJumpsLeft = playerData.amountOfJump;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            playerManager.SetVelocityY(playerData.jumpVelocity);
            isAbilityDone = true;
            DecreaseAmountOfJumps();
            playerManager.AirState.StartJumping();
        }
        
        public bool CheckAmountOfJump() => _amountOfJumpsLeft > 0;

        public void ResetAmountOfJump() => _amountOfJumpsLeft = playerData.amountOfJump;

        public void DecreaseAmountOfJumps() => --_amountOfJumpsLeft;

    }
}