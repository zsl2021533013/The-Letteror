using Character.Base.Base_Manager;
using Character.Core.Core_Component.Move_Core;
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

        public PlayerJumpState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
            _amountOfJumpsLeft = coreManager.MoveCore.PlayerData.amountOfJump;
        }

        
        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.PlayerData.jumpVelocity);
            isAbilityDone = true;
            DecreaseAmountOfJumps();
           manager.AirState.StartJumping();
        }

        public bool CheckAmountOfJump() => _amountOfJumpsLeft - (manager.isDoubleJumpEnable ? 0 : 1) > 0;

        public void ResetAmountOfJump() => _amountOfJumpsLeft = coreManager.MoveCore.PlayerData.amountOfJump;

        public void DecreaseAmountOfJumps() => --_amountOfJumpsLeft;

    }
}